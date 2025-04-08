using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Interfaces
{
    public interface IAddressServices
    {
        public Address GetAddressById(int id);
        public int CreateNewAddress(Address address);
    }
}
