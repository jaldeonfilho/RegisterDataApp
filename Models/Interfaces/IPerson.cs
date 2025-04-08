using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    internal interface IPerson
    {
        public string GetUserFullName(int userId);
        public abstract string WarCrySpeach();
        public List<Person> GetAllPersons();

    }
}
