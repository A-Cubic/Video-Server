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
    public class vlistController : Controller
    {
        private VideoBuss buss = new VideoBuss();

        [HttpGet("{func}/{id}/{inner}")]
        public string Get(string func, string id, bool inner)
        {
            switch(func)
            {
                case "homepage":
                    return buss.GetHomePageByCompanyId(id, inner);
                case "entry":
                    return buss.GetEntryByHomePageId(id, inner);
                case "item":
                    return buss.GetItemsByEntryId(id, inner);
                case "video":
                    return buss.GetVideoByItemId(id, inner);
                case "goods":
                    return buss.GetGoodsByVideoId(id);
                default:
                    return buss.GetHomePageByCompanyId(id, inner);
            }
        }
    }
}
