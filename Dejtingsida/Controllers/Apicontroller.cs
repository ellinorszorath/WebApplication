using Datalager;
using Datalager.Models;
using Dejtingsida.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [Route("post")]
        public void SkickaPost(Datalager.Models.Inlägg meddelande)
        {
            try
            {
                var inlaggMeddelande = meddelande.Message;
                var inlaggMottagare = meddelande.Mottagare;
                var inlaggAvsändare = meddelande.Sender;
                var inlaggTid = meddelande.Skapad;
                var inlaggId = meddelande.Id;

                _dejtingContext.Inlägg.Add(new Datalager.Models.Inlägg
                {
                    Message = inlaggMeddelande,
                    Sender = inlaggAvsändare,
                    Mottagare = inlaggMottagare,
                    Skapad = inlaggTid,
                    Id = inlaggId
                });
                _dejtingContext.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Gick inte att spara inlägg.");
            }
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
