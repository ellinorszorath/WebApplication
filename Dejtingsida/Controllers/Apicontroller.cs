using Datalager;
using Datalager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
        
        [IgnoreAntiforgeryToken(Order = 1001)]
        [HttpPost]
        [Route("skickapost")]
        public String SkickaPost(Inlägg inlägg)
        {
            try
            {
            var inloggadAnvändare = (ClaimsIdentity)User.Identity;
            string AnvID = inloggadAnvändare.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            inlägg.SkickareID = AnvID;
            inlägg.Skapad = DateTime.Now;

            _dejtingContext.Inlägg.Add(inlägg);
             _dejtingContext.SaveChanges();

            return "Post skickad";
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Post misslyckades"; throw;
            }
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

        [HttpGet("{id}")]
        [Route("get")]
        public string GetInloggadAnvändare()
        {
            return "value";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
