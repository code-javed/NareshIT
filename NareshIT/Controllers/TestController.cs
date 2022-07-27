using NareshIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NareshIT.Controllers
{
    public class TestController : ApiController
    {
        public IEnumerable<tblEmployee> Get()
        {
            EmployeeDetails ed = new EmployeeDetails();
            ed.Configuration.ProxyCreationEnabled = false;
            var emp = ed.tblEmployees.ToList();

            //ed.Configuration.ProxyCreationEnabled = false;
            //var dep = ed.tblDepartments.ToList();

            //EmpDep empDep = new EmpDep();
            //empDep.employeeInfo = emp;
            //empDep.departmentInfo = dep;


            return emp;
        }
    }
}
