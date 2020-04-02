using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstWebApi.Controllers
{
    [Route("api/values")] //name should be api/[name before "Controller" in the class], so ValuesController, api/values.  This is the url/end point that the controller should be available from 
    [ApiController] // what kind of controller to make available
    public class ValuesController : ControllerBase 
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> ObtainValueStrings()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/{id}
        [HttpGet("{id}")] // can do multiple with "/" between: [HttpGet("{id}/{name}/{price}")] leave out of curly braces to hard code text(literal)
        public IActionResult EchoBackANumber(int id)
        {
            if (id == 1000)
            {
                return NotFound("You suck at life.");
            }

            return Ok(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
