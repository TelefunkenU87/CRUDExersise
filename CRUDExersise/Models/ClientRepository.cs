using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appDbContext;
        public ClientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Client Add(Client newClient)
        {
            _appDbContext.Add(newClient);
            return newClient;
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public Client Delete(int clientId)
        {
            var client = GetClientById(clientId);
            if(client != null)
            {
                _appDbContext.Remove(client);
            }
            return client;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _appDbContext.Clients;
        }

        public Client GetClientById(int clientId)
        {
            return _appDbContext.Clients.Find(clientId);
        }

        public IEnumerable<Client> GetClientsByName(string name)
        {
            return _appDbContext.Clients.Where(c => string.IsNullOrEmpty(name) || c.ClientName.StartsWith(name));
        }

        public Client Update(Client updatedClient)
        {
            var entity = _appDbContext.Attach(updatedClient);
            entity.State = EntityState.Modified;
            return updatedClient;
        }
    }
}
