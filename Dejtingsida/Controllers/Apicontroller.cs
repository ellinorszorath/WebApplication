using Datalager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dejtingsida.Controllers
{
    [ApiController]
    public class Apicontroller : ControllerBase
    {
        private readonly DejtingContext _dejtingContext;

        public Apicontroller(DejtingContext dejtingContext)
        {
            _dejtingContext = dejtingContext;
        }
        [Route("api/[controller]")]
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //return new string[] { "value1", "value2" };
            return (IEnumerable<string>)_dejtingContext.Users.ToList();

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
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
