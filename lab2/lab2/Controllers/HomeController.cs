using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class HomeController : Controller
    {
 //
 // GET: /Home/
        Club myClub = new Club
    {
     ProductID = 1,
     Name = "Kayak Madrid",
     Description = "the most popular clum in spain",
     Category = "Goverment mandated",
     Price = 275M
    };
        public ActionResult Index()
        {
            return View(myClub);
        }        public ActionResult NameAndPrice()
        {
            return View(myClub);
        }        public ActionResult DemoExpression()
        {
            ViewBag.PlayerCount = 9;
            ViewBag.National = true;            
            ViewBag.Foreign = false;

            return View(myClub);
        }        public ActionResult DemoArray()
        {
            Club[] array = {
     new Club {Name = "Kayak Madrid", Price = 275M},
    new Club {Name = "Shahtar", Price = 48.95M},
    new Club {Name = "Dynamo", Price = 19.50M},
     new Club {Name = "Manchester United", Price = 34.95M}
 };
            return View(array);
        }    }
}