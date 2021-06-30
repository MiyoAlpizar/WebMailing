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
using WebMailing.Models;
using WebMailing.Models.Entities;
using WebMailing.Models.ViewModels;

namespace WebMailing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly IWorkContainer container;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IWorkContainer container)
        {
            _logger = logger;
            this.mapper = mapper;
            this.container = container;
        }

        public async Task<IActionResult> Index(string LastName = null, bool Ascending = true)
        {
            IEnumerable<User> users;
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                users = await container.Users.GetList(x => x.LastName.ToLower() == LastName.ToLower(), Ascending , x => x.LastName, x => x.FirstName);
            }else
            {
                users = await container.Users.GetList(null, Ascending ,x => x.LastName, x => x.FirstName);
            }

            var ascending = new List<AscendingOrder> {
                new AscendingOrder { Name = "Ascending", IsAscending = true } ,
                new AscendingOrder { Name = "Descending", IsAscending = false }
            };
            
            ViewData["Ascending"] = new SelectList(ascending, "IsAscending", "Name");
            
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
