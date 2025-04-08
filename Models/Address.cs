using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int DoorNumber { get; set; }
        public string PostalCode {  get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Locale { get; set; }

        public Address() 
        {
            //Address address = new Address();
        }

        public Address(string street1, string street2, int doorNumber, string city, string postalCode, string region, string locale) : this()
        {
            this.Street1 = street1;
            this.Street2 = street2;
            this.DoorNumber = doorNumber;
            this.City = city;
            this.PostalCode = postalCode;
            this.Region = region;
            this.Locale = locale;
        }
    }
}
