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
        public Client GetClientByEmail(string email);
        public Client GetClientByContactEmail(string email);
        public Client GetClientByPhone(string phone);
        public List<Client> GetAllClients();
        public string UpdateClient(Client updatedClient);
        public string DeleteClient(int id);

    }
}
