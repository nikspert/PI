using lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        TypeContext db = new TypeContext();

        public ActionResult Index()
        {
            IEnumerable<Models.Type> types = db.Types;
            ViewBag.Types = types;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            order.Date = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибі," + order.Person + ", за покупку!";
        }

    }
}