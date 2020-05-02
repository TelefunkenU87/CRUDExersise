using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> AllEmployees { get; }
        Employee GetEmployeeById(int EmpID);
        //IEnumerable<Employee> GetEmployeeByName(string name);
    }
}
