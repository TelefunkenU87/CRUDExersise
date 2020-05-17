using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class MockClientRepository : IClientRepository
    {
        List<Client> _clients;
        public MockClientRepository()
        {
            _clients = new List<Client>()
            {
                new Client { ClientId = 1, ClientName = "North Star Shipping" },
                new Client { ClientId = 2, ClientName = "Ink and Block Press" },
                new Client { ClientId = 3, ClientName = "Cottage Industry Inc" },
                new Client { ClientId = 4, ClientName = "Lisa's lemonade" },
                new Client { ClientId = 5, ClientName = "The Law Offices of Bob Loblaw" }
            };
        }
        public Client Add(Client newClient)
        {
            if (_clients.Count != 0)
            {
                newClient.ClientId = _clients.Max(a => a.ClientId) + 1;
            }
            else
            {
                newClient.ClientId = 1;
            }
            _clients.Add(newClient);
            return newClient;
        }

        public IEnumerable<Client> AllClients()
        {
            return _clients;
        }

        public int Commit()
        {
            return 0;
        }

        public Client Delete(int clientId)
        {
            var client = _clients.FirstOrDefault(c => c.ClientId == clientId);
            if (client != null)
            {
                _clients.Remove(client);
            }
            return client;
        }

        public Client GetClientById(int clientId)
        {
            return _clients.SingleOrDefault(c => c.ClientId == clientId);
        }

        public IEnumerable<Client> GetClientsByName(string name)
        {
            return _clients.Where(c => string.IsNullOrEmpty(name) || c.ClientName.StartsWith(name));
        }

        public Client Update(Client updatedClient)
        {
            var client = _clients.SingleOrDefault(c => c.ClientId == updatedClient.ClientId);
            if (client != null)
            {
                client.ClientId = updatedClient.ClientId;
                client.ClientName = updatedClient.ClientName;
            }
            return client;
        }
    }
}
