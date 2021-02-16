using Datalager;
using Datalager.Models;
using Dejtingsida.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dejtingsida.Controllers
{
    /*[Authorize]*/ //Gör så att man behöver logga in för att kunna komma åt controllern
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DejtingContext _dejtingContext;

        public HomeController(ILogger<HomeController> logger, DejtingContext dejtingContext)
        {
            _logger = logger;
            _dejtingContext = dejtingContext;
        }

        public IActionResult Index()
        {
            var användareProfiler = _dejtingContext.Users.ToList();

            var användare = användareProfiler.Select(a => new Registrerad
            {
                //Id = a.Id,
                Förnamn = a.UserName,
            }).ToList();
            return View(användare);
        }
        [Authorize]
        public IActionResult Profil()
        {
            return View();
        }
        [Authorize]
        public IActionResult _LoginPartial()
        {
            return View();
        }
        [Authorize]
        public IActionResult Registrera()
        {
            return View();
        }
        [Authorize]
        public IActionResult Anvandare()
        {
            return View();
        }
        [Authorize]
        public IActionResult Redigera()
        {
            return View();
        }
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
