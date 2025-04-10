using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : Person
    {
        public Address ContactAddress { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int ContactAddressId { get; set; }


        public Client() {}

        public Client(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt, string contactName, string contactEmail, string contactPhone) : base(firstName, middleName, lastName, birthdate, email, accpetedRgdpt)
        {
            this.ContactName = contactName;
            this.ContactEmail = contactEmail;
            this.ContactPhone = contactPhone;
        }
        public Client(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt, string street1, string street2, int doorNumber, string city, string postalCode, string region, string locale) : base(firstName, middleName, lastName, birthdate, email, accpetedRgdpt)
        {
            this.ContactEmail = email;
            this.ContactAddress = new Address(street1, street2, doorNumber, city, postalCode, region, locale);
        }

        public override string WarCrySpeach()
        {
            return "BANZAI!";
        }
    }
}
