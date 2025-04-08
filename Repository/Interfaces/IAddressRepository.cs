using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interfaces
{
    public interface IAddressRepository
    {
        public int CreateNewAddress(Address address);
        public Address GetAddressById(int id);
    }
}
