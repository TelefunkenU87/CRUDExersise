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

        public Employee Add(Employee newEmployee)
        {
            if (_employees.Count != 0)
            {
                newEmployee.EmpID = _employees.Max(e => e.EmpID) + 1;
            }
            else
            {
                newEmployee.EmpID = 1;
            }
            _employees.Add(newEmployee);
            return newEmployee;
        }

        public IEnumerable<Employee> AllEmployees()
        {
            return _employees;
        }

        public Employee Delete(int employeeId)
        {
            var employee = _employees.FirstOrDefault(e => e.EmpID == employeeId);
            if(employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _employees.SingleOrDefault(e => e.EmpID == employeeId);
        }

        public IEnumerable<Employee> GetEmployeeByName(string name = null)
        {
            return _employees.Where(e => string.IsNullOrEmpty(name) || e.LastName.StartsWith(name) || e.FirstName.StartsWith(name));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _employees.SingleOrDefault(e => e.EmpID == updatedEmployee.EmpID);
            if(employee != null)
            {
                employee.EmailAlias = updatedEmployee.EmailAlias;
                employee.LastName = updatedEmployee.LastName;
                employee.FirstName = updatedEmployee.FirstName;
                employee.MiddleName = updatedEmployee.MiddleName;
                employee.Office = updatedEmployee.Office;
                employee.Region = updatedEmployee.Region;
            }
            return employee;
        }
    }
}
