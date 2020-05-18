using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class Employee
    {
        public Employee()
        {
            Assignments = new List<Assignment>();
        }
        public int EmployeeId { get; set; }

        [Display(Name = "Email Alias")]
        public string EmailAlias { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Office")]
        public string Office { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
