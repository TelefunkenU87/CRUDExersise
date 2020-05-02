using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        List<Employee> _employees;
        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee { EmpID = 1, EmailAlias = "lheinschke", LastName = "Heinschke", FirstName = "Stewart", MiddleName = "Lucilia", Office = "Miami", Region = "South" },
                new Employee { EmpID = 2, EmailAlias = "apietesch", LastName = "Pietesch", FirstName = "Shayna", MiddleName = "Archaimbaud", Office = "DC", Region = "East" },
                new Employee { EmpID = 3, EmailAlias = "pfarrow", LastName = "Farrow", FirstName = "Phelia", MiddleName = "Pavlov", Office = "Lexington", Region = "Central" },
                new Employee { EmpID = 4, EmailAlias = "skembley", LastName = "Kembley", FirstName = "Sharron", MiddleName = "Sherry", Office = "Phoenix", Region = "West" },
                new Employee { EmpID = 5, EmailAlias = "wmunroe", LastName = "Munroe", FirstName = "Willard", MiddleName = "Wally", Office = "Bozeman", Region = "North" }
            };
        }

        public IEnumerable<Employee> AllEmployees()
        {
            return _employees;
        }

        //public IEnumerable<Employee> AllEmployees =>
        //    new List<Employee>
        //    {
        //        new Employee {EmpID = 1, EmailAlias = "lheinschke", LastName = "Heinschke", FirstName = "Stewart", MiddleName = "Lucilia", Office = "Miami", Region = "South" },
        //        new Employee {EmpID = 2, EmailAlias = "apietesch", LastName = "Pietesch", FirstName = "Shayna", MiddleName = "Archaimbaud", Office = "DC", Region = "East"},
        //        new Employee {EmpID = 3, EmailAlias = "pfarrow", LastName = "Farrow", FirstName = "Phelia", MiddleName = "Pavlov", Office = "Lexington", Region = "Central"},
        //        new Employee {EmpID = 4, EmailAlias = "skembley", LastName = "Kembley", FirstName = "Sharron", MiddleName = "Sherry", Office = "Phoenix", Region = "West"},
        //        new Employee {EmpID = 5, EmailAlias = "wmunroe", LastName = "Munroe", FirstName = "Willard", MiddleName = "Wally", Office = "Bozeman", Region = "North"}
        //    };

        public Employee GetEmployeeById(int employeeId)
        {
            //return AllEmployees.FirstOrDefault(e => e.EmpID == employeeId);
            return _employees.SingleOrDefault(e => e.EmpID == employeeId);
        }

        public IEnumerable<Employee> GetEmployeeByName(string name = null)
        {
            return _employees.Where(e => string.IsNullOrEmpty(name) || e.LastName.StartsWith(name) || e.FirstName.StartsWith(name));
        }
    }
}
