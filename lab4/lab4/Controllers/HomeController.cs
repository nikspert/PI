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

        public ActionResult Details(int id = 0)
        {
            Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
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