using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDExersise.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExersise.Controllers
{
    //[Authorize]
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
        public IActionResult List()
        {
            return View(_assignmentRepository.GetAllAssignments());
        }

        public IActionResult Details(int clientId, int employeeId)
        {
            var assignment = _assignmentRepository.GetAssignment(clientId, employeeId);
            assignment.Client = _clientRepository.GetClientById(clientId);
            assignment.Employee = _employeeRepository.GetEmployeeById(employeeId);
            return View(assignment);
        }

        public IActionResult ClientDetails(int id)
        {
            var assignments = _assignmentRepository.GetAssignmentsByClientId(id);
            if (assignments.Count != 0)
            {
                foreach (var item in assignments)
                {
                    item.Client = _clientRepository.GetClientById(item.ClientId);
                    item.Employee = _employeeRepository.GetEmployeeById(item.EmployeeId);
                }
                return View(assignments);
            }
            else
            {
                //TODO: Add redirect to create assignment for client
                return NotFound();
            }
        }

        public IActionResult EmployeeDetails(int id)
        {
            var assignments = _assignmentRepository.GetAssignmentsByEmployeeId(id);
            if (assignments.Count != 0)
            {
                foreach (var item in assignments)
                {
                    item.Client = _clientRepository.GetClientById(item.ClientId);
                    item.Employee = _employeeRepository.GetEmployeeById(item.EmployeeId);
                }
                return View(assignments);
            }
            else
            {
                //TODO: Add redirect to create assignment for employee
                return NotFound();
            }
        }

        public IActionResult Edit(int? clientId, int? employeeId)
        {
            var assignment = new Assignment();
            if (clientId.HasValue && employeeId.HasValue)
            {
                assignment = _assignmentRepository.GetAssignment(clientId.Value, employeeId.Value);
                assignment.Client = _clientRepository.GetClientById(clientId.Value);
                assignment.Employee = _employeeRepository.GetEmployeeById(employeeId.Value);
            }
            if (clientId == null || employeeId == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        [HttpPost]
        public IActionResult Edit(Assignment updatedAssignment)
        {
            int clientId = 0;
            int employeeId = 0;
            if (updatedAssignment.ClientId > 0 && updatedAssignment.EmployeeId > 0)
            {
                var assignment = _assignmentRepository.Update(updatedAssignment);
                _assignmentRepository.Commit();
                clientId = assignment.ClientId;
                employeeId = assignment.EmployeeId;
            }
            else
            {
                var assignment = _assignmentRepository.Add(updatedAssignment);
                _assignmentRepository.Commit();
                clientId = assignment.ClientId;
                employeeId = assignment.EmployeeId;
            }
            //TempData["Message"] = "Assignment data saved";
            return RedirectToAction("List");
        }
    }
}