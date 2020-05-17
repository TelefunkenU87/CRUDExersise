using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public interface IClientRepository
    {
        IEnumerable<Client> AllClients();
        Client GetClientById(int assignmentId);
        IEnumerable<Client> GetClientsByName(string name);
        Client Update(Client updatedClient);
        Client Add(Client newClient);
        Client Delete(int clientId);
        int Commit();
    }
}
