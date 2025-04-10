using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public DateTime BirtDate { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public bool AcceptedRGDPT { get; set; }
        public int AddressId { get; set; }

        internal Person() 
        {
            this.FullName = SetFullName(FirstName, MiddleName, LastName);
            this.Age = GetAge(BirtDate);
        }

        internal Person(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt) : this()
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.FullName = SetFullName(firstName, middleName, lastName);
            this.Age = GetAge(birthdate);
            this.BirtDate = birthdate;
            this.Email = email;
            this.AcceptedRGDPT = accpetedRgdpt;
            //this.AddressId = addressId;
        }

        internal Person(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt, 
            string street1, string street2, int doorNumber, string city, string postalCode, string region, string locale) : 
            this(firstName, middleName, lastName, birthdate, email, accpetedRgdpt)
        {
            Address = new Address(street1, street2, doorNumber, city, postalCode, region, locale);
        }
        internal Person(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt,
            Address address) :
            this(firstName, middleName, lastName, birthdate, email, accpetedRgdpt)
        {
            Address = address;
        }

        private string SetFullName(string firstName, string middleName, string lastName)
        {
            string fullName = firstName;

            if(middleName != null)
                fullName += " " + middleName;

            fullName += " " + lastName;

            return fullName;
        }

        private string SetFullName(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;

            return fullName;
        }

        private int GetAge(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;

            return age;
        }

        public virtual string GetUserFullName(int userId)
        {
            // Got to repository and ask for data
            return ""; // this.FirstName;
        }

        public virtual string WarCrySpeach()
        {
            return "";
        }

        public List<Person> GetAllPersons()
        {
            // Go to a repository and ask for data
            return new List<Person>();
        }
    }
}
