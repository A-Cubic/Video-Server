using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoServer.Buss;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoServer.Controllers
{
    [Route("api/[controller]")]
    public class VListController : Controller
    {
        private VideoBuss buss = new VideoBuss();

        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return buss.getTestString();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return buss.getVList();
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}
