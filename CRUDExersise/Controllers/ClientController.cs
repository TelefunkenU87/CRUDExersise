using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDExersise.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExersise.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult List(string name = null)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            ViewBag.SearchString = name;
            return View(_clientRepository.GetClientsByName(name));
        }

        public IActionResult Details(int id)
        {
            var client = _clientRepository.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View(client);
        }
    }
}