using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021067.Web.Controllers
{
    [RoutePrefix("thu-nghiem")]
    public class TestController : Controller
    {
        // GET: Test
        [Route("xin-chao/{name?}")]
       public string SayHello(String name)
        {
            return $"Hello {name}";
        }
    }
}