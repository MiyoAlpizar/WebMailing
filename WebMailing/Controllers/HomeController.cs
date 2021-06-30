using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            var user = mapper.Map<User>(userViewModel);
            var newUser = await container.Users.Add(user);
            return RedirectToAction(nameof(Confirmation) ,new { @id = newUser.Id });
        }


        public async Task<IActionResult> Confirmation(int id)
        {
            var user = await container.Users.Get(id);
            return View(mapper.Map<UserViewModel>(user));
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
