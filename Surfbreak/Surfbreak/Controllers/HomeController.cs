using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Surfbreak.Models;

namespace Surfbreak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        object locker = new object();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        [Route("")]
        [Route("/[controller]")]
        [Route("/[controller]/index")]
        public IActionResult Index()
        {
            Contact contact = new Contact()
            {
                //informationerne bør nok sættes i en form for settings, og blive kaldt dynamisk ind her
                Email = "info@surfbreak.dk",
                Location = "Denmark, DK",
                Phone = "+45 12 23 34 45"
            };
            
            return View(contact);
        }
        [Route("/privacy")]
        [Route("/[controller]/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        #region --¤ Gammel kode fra en tidligere opgave ¤--
        //[Route("/Login")]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        /*
        [HttpGet, Route("/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("/Create")]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View();
            //user.IsAdmin = false;
            _repo.Add(user);
            _repo.SaveChanges();
            return View();
        }
        [HttpGet, Route("/Users")]
        public IActionResult Users()
        {
            var model = _repo.Users.ToList();
            return View(model);
        }
        [Route("/EditUser/{id}")]
        [Route("/Edit/{id}")]
        [HttpGet]
        public IActionResult EditUser(long id)
        {
            User user = _repo.Users.First(x => x.Id == id);
            return View(user);
        }
        [HttpPost, Route("/Edit/{id}")]
        public IActionResult EditUser(User user)
        {
            _repo.Update(user);
            _repo.SaveChanges();
            return RedirectToAction("Users", "Home");
        }
        */
        #endregion
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
