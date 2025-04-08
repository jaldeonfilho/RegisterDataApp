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
    public class AddressServices : IAddressServices
    {
        private AddressRepository _addressRepository { get; set; }

        public AddressServices() 
        {
            _addressRepository = new AddressRepository();
        }

        public Address GetAddressById(int id)
        {
            Address address = _addressRepository.GetAddressById(id);
            return address;
        }

        public int CreateNewAddress(Address address)
        {
            //string message = "";

            int addressid = _addressRepository.CreateNewAddress(address);

            //message = "User create with success";
            
            //message = "There as one or more errors in your information." + message;

            return addressid;
        }
    }
}
