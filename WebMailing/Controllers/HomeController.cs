using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMailing.DataAccess.Interfaces;
using WebMailing.Helpers;
using WebMailing.Models;
using WebMailing.Models.Entities;
using WebMailing.Models.ViewModels;

namespace WebMailing.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWorkContainer container;

        public HomeController(IMapper mapper, IWorkContainer container)
        {
            this.mapper = mapper;
            this.container = container;
        }

        public async Task<IActionResult> Index(string LastName = null, bool Ascending = true)
        {
            var users = await container.Users.GetUsersOrder(LastName, Ascending);
            var ascendingList = Constants.AscendingList;
            ViewData["Ascending"] = new SelectList(ascendingList, "IsAscending", "Name");   
            return View(new IndexViewModel { LastNameFilter = LastName, Users = users, Ascending = Ascending });
        }

        [HttpPost, ActionName("Index")]
        public IActionResult FilterIndex(IndexViewModel model)
        {
            return RedirectToAction(nameof(Index), new { LastName = model.LastNameFilter, Ascending = model.Ascending });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUser userViewModel)
        {
            var user = mapper.Map<User>(userViewModel);
            var newUser = await container.Users.Add(user);
            return RedirectToAction(nameof(Confirmation) ,new { @id = newUser.Id });
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var user = await container.Users.Get(id);
            return View(mapper.Map<CreateUser>(user));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
