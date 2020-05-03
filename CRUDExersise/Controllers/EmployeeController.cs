using CRUDExersise.Models;
using CRUDExersise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUDExersise.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: /<controller>/
        //public IActionResult List()
        //{
        //    //EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
        //    //employeeListViewModel = _employeeRepository.AllEmployees;
        //    return View(_employeeRepository.AllEmployees());
        //}

        public IActionResult List(string name = null)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            ViewBag.SearchString = name;
            return View(_employeeRepository.GetEmployeeByName(name));
        }

        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound();
            }
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            var employee = new Employee();
            if (id.HasValue)
            {
                employee = _employeeRepository.GetEmployeeById(id.Value);
            }
            //else
            //{
            //    var employee = new Employee();
            //}
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee updatedEmployee)
        {
            int Id = 0;
            if (updatedEmployee.EmployeeId > 0)
            {
                var employee = _employeeRepository.Update(updatedEmployee);
                _employeeRepository.Commit();
                Id = employee.EmployeeId;
            }
            else
            {
                var employee = _employeeRepository.Add(updatedEmployee);
                _employeeRepository.Commit();
                Id = employee.EmployeeId;
            }
            //_employeeRepository.Commit();
            TempData["Message"] = "Employee data saved";
            return RedirectToAction("Details", new { id = Id });
        }

        public IActionResult Delete(int Id)
        {
            var employee = _employeeRepository.GetEmployeeById(Id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            var employee = _employeeRepository.Delete(Id);
            _employeeRepository.Commit();

            if(employee == null)
            {
                return NotFound();
            }
            TempData["Message"] = $"{employee.LastName}, {employee.FirstName} was successfully deleted";
            return RedirectToAction("List");
        }
    }
}
