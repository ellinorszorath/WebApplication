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
using Microsoft.AspNetCore.Identity;

namespace Dejtingsida.Controllers
{
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

        public IActionResult Sök(string Sok) 
        {
            try
            {
                var Anvandare = _userManager.Users;

                if (!String.IsNullOrEmpty(Sok))
                {
                    Anvandare = Anvandare.Where(u => u.Förnamn.Contains(Sok) && u.Visas == true);

                }
                return View(new SökViewModel {anvandare = Anvandare.ToList(), SökSträng = Sok });
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return View(new ErrorViewModel());
            }

        }
    }
    }


