using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IClientRepository
    {
        public void CreateNewClient(Client client);
        public Client GetClientById(int id);
        public Client GetClientByEmail(string email);
        public Client GetClientByContactEmail(string contactEmail);
        public Client GetClientByPhone(string phone);
        public List<Client> GetAllClients();
        public void UpdateClient(Client client);
        public void DeleteClient(int id);

    }
}
