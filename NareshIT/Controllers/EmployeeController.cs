using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NareshIT.Models;

namespace NareshIT.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEmployeeDetails()
        {
            EmployeeDetails ed = new EmployeeDetails();
            var emp = ed.tblEmployees.ToList();
            var dep = ed.tblDepartments.ToList();

            EmpDep empDep = new EmpDep();
            empDep.employeeInfo = emp;
            empDep.departmentInfo = dep;
            return View(empDep);
        }

        [HttpPost]
        public ActionResult AddEmployee(tblEmployee employee)
        {
            EmployeeDetails ed = new EmployeeDetails();

            if (ModelState.IsValid)
            {
                ed.tblEmployees.Add(employee);
                ed.SaveChanges();
                ViewBag.Message = "Employee record saved successfully!";
                //return Content("<script>alert('Employee record saved successfully!');</script>");
            }

            var dep = ed.tblDepartments.ToList();
            EmpDep e = new EmpDep();
            e.departmentInfo = dep;
            ViewBag.DepList = e;

            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(tblDepartment department)
        {
            return View();
        }
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeDetails ed = new EmployeeDetails();
            var response = ed.tblEmployees.Where(x => x.empId == id).FirstOrDefault();
            ed.tblEmployees.Remove(response);
            ed.SaveChanges();

            ViewBag.Message = "Employee record deleted form id " + id;

            return RedirectToAction("GetEmployeeDetails");
        }
    }
}