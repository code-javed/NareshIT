using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NareshIT.Models
{
    public class EmpDep
    {
        public List<tblEmployee> employeeInfo { get; set; }
        public List<tblDepartment> departmentInfo { get; set; }
    }
}