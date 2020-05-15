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
        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        public IActionResult List(string name = null)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            ViewBag.SearchString = name;
            return View(_assignmentRepository.GetAssignmentByName(name));
        }
    }
}