using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.UI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public string BuscarPorId(int id) 
        {
            return "maxi";
        }

        // POST api/values
        public void Post()
        {
            
        }

        // PUT api/values/5
        public void Put()
        {
            
        }



        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
