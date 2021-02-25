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
            string id = _userManager.GetUserId(User);
            var vänförfrågning = _dejtingContext.Vänförfrågning.Where(f => f.Accepterad == true && f.MottagareID.Equals(id) || f.FörfrågareID.Equals(id));
            var skickareID = vänförfrågning.Select(f => f.FörfrågareID);
            var profiler = new List<Registrerad>();
            foreach (string x in skickareID)
            {
                var p = _dejtingContext.Registrering.Find(x);
                profiler.Add(p);
            }

            return View(profiler);
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

                return RedirectToAction("Index", "Profil", new { id});
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

        public IActionResult AvvisaVänförfrågan(string id)
        {
            try
            {
                string anv = _userManager.GetUserId(User);

                var vän = _dejtingContext.Vänförfrågning.Where(f => f.Accepterad == false && f.MottagareID.Equals(id) || f.FörfrågareID.Equals(id)
                    && f.MottagareID.Equals(anv) || f.FörfrågareID.Equals(anv)).FirstOrDefault();
                _dejtingContext.Vänförfrågning.Remove(vän);
                _dejtingContext.SaveChanges();

                return RedirectToAction("Vänförfrågningar", "Vänner", new { id });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return View(new ErrorViewModel());
            }
        }

        public IActionResult TaBortVän(string id)
        {
            try
            {
                string anv = _userManager.GetUserId(User);

                var vän = _dejtingContext.Vänförfrågning.Where(f => f.MottagareID.Equals(id) || f.FörfrågareID.Equals(id)
                    && f.MottagareID.Equals(anv) || f.FörfrågareID.Equals(anv)).FirstOrDefault();

                _dejtingContext.Vänförfrågning.Remove(vän);
                _dejtingContext.SaveChanges();

                return RedirectToAction("Index", "Vänner", new { id });
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
