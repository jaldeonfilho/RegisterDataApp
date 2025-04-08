using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {
        public int NIF { get; set; }
        public int NIB { get; set; }
        public string JobRole { get; set; }
        public string JobDescription { get; set; }
        public string ManagerName { get; set; }
        public bool NeedsNDA { get; set; }
        public int JobId { get; set; }

        public Employee()
        {

        }

        public Employee(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt, int addressId, 
            int nib, int nif, string jobRole, string jobDescription, string managerName) : 
            base(firstName, middleName, lastName, birthdate, email, accpetedRgdpt, addressId)
        {
            this.NIF = nif;
            this.NIB = nib;
            this.JobRole = jobRole;
            this.JobDescription = jobDescription;
            this.ManagerName = managerName;
        }

        public Employee(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt, int addressId,
            int nib, int nif, string jobRole, string jobDescription, string managerName, Address address) :
            this(firstName, middleName, lastName, birthdate, email, accpetedRgdpt, addressId, nif, nib, jobRole, jobDescription, managerName)
        {
            this.Address = address;
        }

        public override string ToString()
        {
            string newText = this.FullName + " " + this.Age;
            return newText;
        }

        public Employee CreateNewEmployeeAndReturnContent(string firstName, string middleName, string lastName, DateTime birthdate, string email, bool accpetedRgdpt, int addressId, 
            int nib, int nif, string jobRole, string jobDescription, string managerName, Address address)
        {
            Employee employee = new Employee(firstName, middleName, lastName, birthdate, email, accpetedRgdpt, addressId, 
                nib, nif, jobRole, jobDescription, managerName, address);
            return employee;
        }

        public override string GetUserFullName(int userId)
        {
            return "";
        }

        public override string WarCrySpeach()
        {
            return "SHOW ME THE MONEY!";
        }
    }
}
