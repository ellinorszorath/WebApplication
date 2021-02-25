using Datalager;
using Datalager.Models;
using Dejtingsida.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dejtingsida.Controllers
{
    public class ProfilController : Controller
    {
        public readonly UserManager<Registrerad> _userManager;
        private readonly DejtingContext _dejtingContext;
        public ProfilController(DejtingContext dejtingContext, UserManager<Registrerad> anvandare)
        {
            _userManager = anvandare;
            _dejtingContext = dejtingContext;
        }
        [Authorize]
        [Route("Profil")]
        public IActionResult Index()
        {
            try
            {
                ClaimsPrincipal claim = this.User;
                Registrerad Anvandare = _userManager.GetUserAsync(claim).Result;
                AnvandareViewModel model = new AnvandareViewModel()
                {
                    Anvandare = Anvandare,
                    InläggLista = _dejtingContext.Inlägg.ToList()
                };

                return View(model);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return View();
            }
        }
        [Authorize]
        [Route("Profil/{Id}")]
        public IActionResult Index(string Id)
        {
            Registrerad Anvandare;
            if (_userManager.FindByIdAsync(Id).Result != null)
            {

                Anvandare = _userManager.FindByIdAsync(Id).Result;
                AnvandareViewModel Model = new AnvandareViewModel()
                {
                    Anvandare = Anvandare,
                    InläggLista = _dejtingContext.Inlägg.ToList()
                };
                return View(Model);
            }
            else
            {

                return View("Error");
            }

        }
    
        }

    }

