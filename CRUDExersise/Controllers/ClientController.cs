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

        public IActionResult Edit(int? id)
        {
            var client = new Client();
            if(id.HasValue)
            {
                client = _clientRepository.GetClientById(id.Value);
            }
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client updatedClient)
        {
            int Id = 0;
            if (updatedClient.ClientId > 0)
            {
                var client = _clientRepository.Update(updatedClient);
                _clientRepository.Commit();
                Id = client.ClientId;
            }
            else
            {
                var client = _clientRepository.Add(updatedClient);
                _clientRepository.Commit();
                Id = client.ClientId;
            }
            TempData["Message"] = "Client data saved";
            return RedirectToAction("Details", new { id = Id });
        }

        public IActionResult Delete(int Id)
        {
            var client = _clientRepository.GetClientById(Id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            var client = _clientRepository.Delete(Id);
            _clientRepository.Commit();

            if (client == null)
            {
                return NotFound();
            }
            TempData["Message"] = $"{client.ClientName} was successfully deleted";
            return RedirectToAction("List");
        }
    }
}