using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClientServices
    {
        public string CreateNewClient(Client client);
        public Client GetClientById(int id);
        public List<Client> GetAllClients();
        public string UpdateEmployeeById(Client updatedClient);
        public string DeleteClient(int id);

    }
}
