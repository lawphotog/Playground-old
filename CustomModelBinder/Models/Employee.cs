using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomModelBinder.Models
{
    public class Employee: Person
    {
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
    }
}