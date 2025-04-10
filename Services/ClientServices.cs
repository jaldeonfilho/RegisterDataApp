using Models;
using Repository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientServices : IClientServices
    {
        private ClientRepository _clientRepository { get; set; }
        private AddressServices _addressServices { get; set; }
        public ClientServices()
        {
            _clientRepository = new ClientRepository();
            _addressServices = new AddressServices();
        }
        public string CreateNewClient(Client client)
        {
            _clientRepository.CreateNewClient(client);
            client.ContactAddressId = _addressServices.CreateNewAddress(client.ContactAddress);
            client.ContactAddress.Id = client.ContactAddressId;
            return "Client created with success\n";
        }

        public string UpdateClient(Client updatedClient)
        {
            // Verifica se o funcionário existe
            Client existingClient = _clientRepository.GetClientById(updatedClient.Id);
            if (existingClient == null)
            {
                return "Client not found\n";
            }
            //Client updatedClient = new Client(firstName, middleName, lastName, birthdate, email, addressId,
            //    street1, street2, doorNumber, city, postalCode, region, locale);

            // Atualiza os dados do funcionário
            //updatedClient.Id = existingClient.Id; // Manter o ID do endereço
            _clientRepository.UpdateClient(updatedClient);
            return "Client Updated with success\n";
        }

        public Client GetClientById(int id)
        {
            Client client = _clientRepository.GetClientById(id);
            client.ContactAddress = _addressServices.GetAddressById(client.ContactAddressId);
            return client;
        }
        public List<Client> GetAllClients()
        {
            List<Client> allClients = _clientRepository.GetAllClients();
            foreach (Client client in allClients)
            {
                client.ContactAddress = _addressServices.GetAddressById(client.ContactAddressId);
            }
            return allClients;
        }

        public string DeleteClient(int id)
        {
            Client existingClient = _clientRepository.GetClientById(id);
            if (existingClient == null)
            {
                return "Client not found\n";
            }

            _clientRepository.DeleteClient(id);
            return "Client Deleted with success\n";
        }
    }
}
