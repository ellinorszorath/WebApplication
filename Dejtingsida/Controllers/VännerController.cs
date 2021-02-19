using Microsoft.AspNetCore.Mvc;
using Datalager;
using Dejtingsida.Models;
using Datalager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Dejtingsida.Controllers
{
    public class VännerController : Controller
    {

        private readonly DejtingContext _dejtingContext;
        public readonly UserManager<Registrerad> _userManager;

        public VännerController(UserManager<Registrerad> användare, DejtingContext dejtingContext)
        {
            _dejtingContext = dejtingContext;
            _userManager = användare;
        }
        [Authorize]
        [Route("Vänner/Index")]
        public IActionResult Index()
        {
            try
            {
                ClaimsPrincipal claim = this.User;
                string användareID = _userManager.GetUserAsync(claim).Result.Id;
                var vänner = _dejtingContext.Vänförfrågning.Where(x => (x.MottagareID.Equals(användareID) || x.FörfrågareID.Equals(användareID)) &&
                x.Accepterad == true);

                VännerViewModel nyModell = new VännerViewModel { Registrerad = användareID, Vänförfrågningar = vänner.ToList()};
                return View(nyModell);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }

        }

        [Authorize]
        [Route("Vänner/Vänförfrågningar")]
        public IActionResult Vänförfrågningar()
        {
            try
            {
                ClaimsPrincipal claim = User;

                string användareID = _userManager.GetUserAsync(claim).Result.Id;

                var vänförfrågning = _dejtingContext.Vänförfrågning.Where(x => (x.MottagareID.Equals(användareID)) && x.Accepterad == false);

                VännerViewModel nyModell = new VännerViewModel { Registrerad = användareID, Vänförfrågningar = vänförfrågning.ToList() };

                return View(nyModell);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }


        }
    }
}
