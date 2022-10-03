using NareshIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NareshIT.Controllers
{
    public class JsonStuffController : Controller
    {
        // GET: JsonStuff
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployeeJson()
        {
            EmployeeDetails ed = new EmployeeDetails();
            ed.Configuration.ProxyCreationEnabled = false;
            var emp = ed.tblEmployees.ToList();

            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetEmployeeDetails()
        {
            return View();
        }
    }
}