using Microsoft.AspNetCore.Mvc;
using Datalager;
using System;
using System.Collections.Generic;
using System.Linq;
using Datalager.Models;
using System.Threading.Tasks;

namespace Dejtingsida.Controllers
{
    public class RedigeraController : Controller
    {
        private readonly DejtingContext _DejtingContext;

        public RedigeraController(DejtingContext dejtingContext)
        {
            _DejtingContext = dejtingContext;
        }

        public IActionResult Index()
        {
            return View("Redigera", "Redigera");
        }

        [HttpPost]
        public IActionResult Redigera(Registrerad profil)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    Datalager.Models.Registrerad inloggadProfil = _DejtingContext.Registrering.SingleOrDefault(x => x.Email == User.Identity.Name);
                    inloggadProfil.Förnamn = profil.Förnamn;
                    inloggadProfil.Efternamn = profil.Efternamn;
                    inloggadProfil.Födelsedatum = profil.Födelsedatum;

                    _DejtingContext.Registrering.Update(inloggadProfil);
                    _DejtingContext.SaveChanges();
                    Console.WriteLine(inloggadProfil);

                }

                catch (Exception exc)
                {
                    return View("Error", exc);
                }

            }

            return RedirectToAction("Profil", "Home");
        }
    }
}