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
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Dejtingsida.Viewmodels;

namespace Dejtingsida.Controllers
{
    /*[Authorize]*/ //Gör så att man behöver logga in för att kunna komma åt controllern
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly UserManager<Registrerad> _userManager;
        private readonly DejtingContext _dejtingContext;

        public HomeController(ILogger<HomeController> logger, DejtingContext dejtingContext, UserManager<Registrerad> users)
        {
            _userManager = users;
            _logger = logger;
            _dejtingContext = dejtingContext;
        }

        public IActionResult Index()
        {
            
            List<Registrerad> användareProfiler = _dejtingContext.Registrering.ToList();

            var användare = användareProfiler.Select(a => new Registrerad
            {
                Förnamn = a.Förnamn,
                Efternamn = a.Efternamn
            }).ToList();
            return View(användare);
            
        }

        [Authorize]
        public IActionResult _LoginPartial()
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

        [Authorize]
        [Route("Profil")]
        public IActionResult Profil()
        {
            try
            {
                ClaimsPrincipal claim = this.User;
                Registrerad user = _userManager.GetUserAsync(claim).Result;
                //Registrerad model = new Registrerad()
                //{
                //    Användare = user,
                //};


                return View(user);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return View();
            }
        }

        [Authorize]
        [Route("Profil/{Id}")]
        public IActionResult Profil(string Id)
        { 
            Registrerad user;
            if (_userManager.FindByIdAsync(Id).Result != null)
            {
               
                user = _userManager.FindByIdAsync(Id).Result;
                //AnvandareViewModel model = new AnvandareViewModel()
                //{
                //    Anvandare = user
                //};
                return View(user);
            }
            else
            {

                return View("Error");
            }
        }
    }
}

