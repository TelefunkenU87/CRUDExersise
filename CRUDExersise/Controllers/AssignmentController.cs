using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDExersise.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExersise.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository, IClientRepository clientRepository, IEmployeeRepository employeeRepository)
        {
            _assignmentRepository = assignmentRepository;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View(_assignmentRepository.GetAllAssignments());
        }
    }
}