using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeekeepersBlog_V2.Controllers
{
    public class PostController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}