using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalager;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace Dejtingsida.Controllers
{
    public class ProfilController : Controller
    {
        private readonly DejtingContext _dejtingContext;

        public ProfilController(DejtingContext dejtingContext)
        {
            _dejtingContext = dejtingContext;
        }
        public IActionResult Index()
        {
            var RegistreradeAnvändare = _dejtingContext.Registrering.ToList();

            var profil = RegistreradeAnvändare.Select(p => new Profil
            {
                Förnamn = p.Förnamn,
                Efternamn = p.Efternamn,
                Användarnamn = p.Användarnamn
            }).ToList();
            return View(profil);
        }

    }
}
