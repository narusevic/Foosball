using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FoosballApi.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/Values/{id}")]
        public string Get(int id)
        {
            var list = new[]
            {
                "Hello",
                "World"
            };

            return list[id];
        }
    }
}