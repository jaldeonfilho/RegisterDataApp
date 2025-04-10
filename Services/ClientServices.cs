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
            client.ContactAddressId = _addressServices.CreateNewAddress(client.ContactAddress);
            client.ContactAddress.Id = client.ContactAddressId;
            _clientRepository.CreateNewClient(client);
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
            updatedClient.ContactAddressId = _addressServices.CreateNewAddress(updatedClient.ContactAddress);
            updatedClient.ContactAddress.Id = updatedClient.ContactAddressId;
            return "Client Updated with success\n";
        }

        public Client GetClientById(int id)
        {
            Client client = _clientRepository.GetClientById(id);
            client.ContactAddress = _addressServices.GetAddressById(client.ContactAddressId);
            return client;
        }
        public Client GetClientByEmail(string email)
        {
            Client client = _clientRepository.GetClientByEmail(email);
            client.ContactAddress = _addressServices.GetAddressById(client.ContactAddressId);
            return client;
        }
        public Client GetClientByContactEmail(string email)
        {
            Client client = _clientRepository.GetClientByContactEmail(email);
            client.ContactAddress = _addressServices.GetAddressById(client.ContactAddressId);
            return client;
        }
        public Client GetClientByPhone(string phone)
        {
            Client client = _clientRepository.GetClientByPhone(phone);
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
