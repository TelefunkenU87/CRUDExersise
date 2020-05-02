using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmailAlias { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Office { get; set; }
        public string Region { get; set; }
    }
}
