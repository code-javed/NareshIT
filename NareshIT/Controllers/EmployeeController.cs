using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NareshIT.Models;

namespace NareshIT.Controllers
{
    [HandleError]
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HandleError]
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
                var empDetails = ed.tblEmployees.Where(x => x.empId == employee.empId).FirstOrDefault();
                if (empDetails != null)
                {
                    EmployeeDetails ed2 = new EmployeeDetails();

                    ed2.Entry(employee).State = EntityState.Modified;
                    ed2.SaveChanges();
                    //ViewBag.Message = "Employee record updated successfully!";
                    return RedirectToAction("GetEmployeeDetails");
                }
                else
                {
                    ed.tblEmployees.Add(employee);
                    ed.SaveChanges();
                    return RedirectToAction("GetEmployeeDetails");
                    //ViewBag.Message = "Employee record saved successfully!";
                    //return Content("<script>alert('Employee record saved successfully!');</script>");
                }
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

        public ActionResult Details(int? id)
        {
            if (id != 0 & id != null)
            {
                EmployeeDetails ed = new EmployeeDetails();
                var response = ed.tblEmployees.Where(x => x.empId == id).FirstOrDefault();
                var depResponse = ed.tblDepartments.Where(x => x.depId == response.departmentId).FirstOrDefault();
                ViewBag.depName = depResponse.depName;
                return View(response);
            }
            return RedirectToAction("GetEmployeeDetails");
        }

        [HttpGet]
        public ActionResult EditEmployee(int? id)
        {
            EmployeeDetails ed = new EmployeeDetails();
            var response = ed.tblEmployees.Where(x => x.empId == id).FirstOrDefault();
            return View("AddEmployee", response);
            //return PartialView("_404");
        }
    }
}