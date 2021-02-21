using Datalager;
using Datalager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dejtingsida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DejtingContext _dejtingContext;

        public ApiController(DejtingContext dejtingContext)
        {
            _dejtingContext = dejtingContext;
        }
        [HttpGet]
        [Route("getData")]
        
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            var AnvändareDB = _dejtingContext.Users.FirstOrDefault();
            return AnvändareDB.UserName;


        }
        [HttpPost]
        [Route("skickapost")]
        public void SkickaPost(Inlägg meddelande)
        {
            try
            {
                var inlaggMeddelande = meddelande.Message;
                var inlaggMottagare = meddelande.MottagareID;
                var inlaggTid = DateTime.UtcNow;
                var inlaggSkickare = meddelande.SkickareID;
                

                _dejtingContext.Inlägg.Add(new Datalager.Models.Inlägg
                {
                    Message = inlaggMeddelande,
                    MottagareID = meddelande.MottagareID,
                    Skapad = inlaggTid,
                    SkickareID = inlaggSkickare
                });
                _dejtingContext.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Gick inte att spara inlägg.");
            }
        }


        [Authorize]
        [HttpGet("skickaVänförfrågan/{mottagare}")]
        public bool SkickaVänförfrågan(string mottagare)
        {
            bool lyckades = false;
            try
            {
                var inloggadAnvändare = (ClaimsIdentity)User.Identity;

                string AnvID = inloggadAnvändare.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                var förfrågan = _dejtingContext.Vänförfrågning.Where(x => (x.MottagareID.Equals(mottagare) &&
                x.FörfrågareID.Equals(AnvID)) || (x.MottagareID.Equals(AnvID) &&
                x.FörfrågareID.Equals(mottagare))).FirstOrDefault();

                if (förfrågan == null)
                {
                    var vänförfrågan = new Vänförfrågning
                    {
                        FörfrågareID = AnvID,
                        MottagareID = mottagare,
                        FörfrågningsDatum = DateTime.Now,
                        Accepterad = false
                    };

                    _dejtingContext.Vänförfrågning.Add(vänförfrågan);
                    _dejtingContext.SaveChanges();
                    lyckades = true;
                }
                else
                {
                    lyckades = false;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                lyckades = false;
            }
            return lyckades;
        }

        [Authorize]
        [HttpGet("avvisaVänförfrågan/{förfrågareID}")]
        public bool AvvisaVänförfrågan(string förfrågareID)
        {
            bool lyckades = false;
            try
            {
                var inloggadAnvändare = (ClaimsIdentity)User.Identity;
                string AnvID = inloggadAnvändare.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                IEnumerable<Vänförfrågning> Vänförfrågning = _dejtingContext.Vänförfrågning.Where(förfrågan => förfrågan.MottagareID.Equals(AnvID) &&
                förfrågan.FörfrågareID.Equals(förfrågareID)
                && förfrågan.Accepterad == false);

                foreach (Vänförfrågning vän in Vänförfrågning)
                {
                    _dejtingContext.Vänförfrågning.Remove(vän);
                }
                _dejtingContext.SaveChanges();
                lyckades = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                lyckades = false;
            }

            return lyckades;
        }

        [Authorize]
        [HttpGet("taBortVän/{anvID}")]
        public bool TaBortVän(string anvID)
        {
            bool lyckades = false;
            try
            {
                var inloggadAnvändare = (ClaimsIdentity)User.Identity;
                string AnvID = inloggadAnvändare.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                IEnumerable<Vänförfrågning> Vänförfrågning =
                _dejtingContext.Vänförfrågning.Where(förfrågan => ((förfrågan.MottagareID.Equals(AnvID) && 
                förfrågan.FörfrågareID.Equals(anvID)) | (förfrågan.MottagareID.Equals(anvID) && 
                förfrågan.FörfrågareID.Equals(AnvID))));

                foreach (Vänförfrågning vän in Vänförfrågning)
                {
                    _dejtingContext.Vänförfrågning.Remove(vän);
                }

                _dejtingContext.SaveChanges();
                lyckades = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                lyckades = false;
            }

            return lyckades;
        }

        [Authorize]
        [HttpGet("räknaVänförfrågningar")]
        public int RäknaVänförfrågningar()
        {
            int antal = 0;
            try
            {
                var inloggadAnvändare = (ClaimsIdentity)User.Identity;
                string AnvID = inloggadAnvändare.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                IEnumerable<Vänförfrågning> Vänförfrågning = _dejtingContext.Vänförfrågning.Where(förfrågan => förfrågan.MottagareID.Equals(AnvID) &&
                förfrågan.Accepterad == false);
                antal = Vänförfrågning.Count();
            }
            catch (Exception ex)
            {
                antal = 0;
                Console.WriteLine(ex.Message);
            }
            return antal;
        }

        [Authorize]
        [HttpGet("accepteraVänförfrågan/{förfrågare}")]
        public bool AccepteraVänförfrågan(string förfrågare)
        {
            bool lyckades = false;
            try
            {
                var inloggadAnvändare = (ClaimsIdentity)User.Identity;
                string AnvID = inloggadAnvändare.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                IEnumerable<Vänförfrågning> Vänförfrågning = 
                _dejtingContext.Vänförfrågning.Where(förfrågan => förfrågan.MottagareID.Equals(AnvID) &&
                förfrågan.FörfrågareID.Equals(förfrågare) && förfrågan.Accepterad == false);

                foreach (Vänförfrågning vän in Vänförfrågning)
                {
                    _dejtingContext.Attach(vän);
                    vän.Accepterad = true;
                    _dejtingContext.Entry(vän).Property(property => property.Accepterad).IsModified = true;
                    _dejtingContext.Vänförfrågning.Update(vän);
                }
                _dejtingContext.SaveChanges();
                lyckades = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                lyckades = false;
            }

            return lyckades;

        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Route("get")]
        public string GetInloggadAnvändare()
        {
            return "value";
        }

        // POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
