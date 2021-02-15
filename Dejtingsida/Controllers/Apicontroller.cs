using Datalager;
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
        public void SkickaPost(Inlägg meddelande)
        {
            var hej = meddelande;
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
