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

        public IActionResult SkickaVänförfrågan(string id)
        {
            try
            {
                ClaimsPrincipal claim = User;
                Vänförfrågning vän = new Vänförfrågning
                {
                    FörfrågareID = _userManager.GetUserAsync(claim).Result.Id,
                    MottagareID = id,
                    Accepterad = false,
                    FörfrågningsDatum = DateTime.Now
                };

                _dejtingContext.Vänförfrågning.Add(vän);
                _dejtingContext.SaveChanges();

                return RedirectToAction("Profil", "Home", new { id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(new ErrorViewModel());
            }
        }

        public IActionResult AccepteraVänförfrågan(string id)
        {
            try
            {
                var inloggadAnvändare = (ClaimsIdentity)User.Identity;
                string AnvID = inloggadAnvändare.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                IEnumerable<Vänförfrågning> Vänförfrågning =
                _dejtingContext.Vänförfrågning.Where(x => x.MottagareID.Equals(AnvID) &&
                x.FörfrågareID.Equals(id) && x.Accepterad == false);

                foreach (Vänförfrågning vän in Vänförfrågning)
                {
                    _dejtingContext.Attach(vän);
                    vän.Accepterad = true;
                    _dejtingContext.Entry(vän).Property(property => property.Accepterad).IsModified = true;
                    _dejtingContext.Vänförfrågning.Update(vän);
                }
                _dejtingContext.SaveChanges();
                return RedirectToAction("Vänförfrågningar", "Vänner", new { id });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return View(new ErrorViewModel());
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
