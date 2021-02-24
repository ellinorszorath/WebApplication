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
