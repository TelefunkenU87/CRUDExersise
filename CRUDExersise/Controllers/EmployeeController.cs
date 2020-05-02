using CRUDExersise.Models;
using CRUDExersise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(employee);
        }
    }
}
