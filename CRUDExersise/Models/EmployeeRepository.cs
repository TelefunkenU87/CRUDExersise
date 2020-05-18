using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Employee Add(Employee newEmployee)
        {
            //var highestEmployeeId = _appDbContext.Employees.OrderByDescending(e => e.EmployeeId).FirstOrDefault();
            //newEmployee.EmployeeId = highestEmployeeId.EmployeeId + 1;
            _appDbContext.Add(newEmployee);
            return newEmployee;
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }
        
        public Employee Delete(int EmpID)
        {
            var employee = GetEmployeeById(EmpID);
            if(employee != null)
            {
                _appDbContext.Remove(employee);
            }
            return employee;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employees;
        }

        public Employee GetEmployeeById(int EmpID)
        {
            return _appDbContext.Employees.Find(EmpID);
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            return _appDbContext.Employees.Where(e => string.IsNullOrEmpty(name) || e.LastName.StartsWith(name) || e.FirstName.StartsWith(name));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var entity = _appDbContext.Attach(updatedEmployee);
            entity.State = EntityState.Modified;
            return updatedEmployee;
        }
    }
}
