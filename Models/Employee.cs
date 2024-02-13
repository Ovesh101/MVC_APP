using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Demo.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}