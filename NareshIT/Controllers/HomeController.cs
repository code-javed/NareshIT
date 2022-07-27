using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NareshIT.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string color)
        {
            ViewBag.Color = color;
            return View();
        }

        public ActionResult Index2(int? id)
        {
            ViewBag.count = id;
            return View();
        }
        public ActionResult ReturnSomeString(string id)
        {
            ViewBag.value = "This is my application, and your user id = " + id;
            //return "This is my application, and your user id = " + id;
            return View();
        }
    }
}