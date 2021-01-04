using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalager;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

    }
}
