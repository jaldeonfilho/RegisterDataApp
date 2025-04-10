using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions.Portugal;
using Models;
using Repository;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private IEmployeeRepository _employeeRepository = new EmployeeRepository();
        private IAddressRepository _addressServices = new AddressRepository();
        public EmployeeServices() 
        {
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employees = _employeeRepository.GetEmployeeById(id);
            employees.Address = _addressServices.GetAddressById(employees.AddressId);
            return employees;
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> _employees = _employeeRepository.GetAll2();
            foreach (Employee employee in _employees) 
            {
                employee.Address = _addressServices.GetAddressById(employee.AddressId);
            }
            return _employees;
        }
        /// <summary>
        /// Create a new employee object
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="middleName">middle name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="birthdate">Birthdate</param>
        /// <param name="accpetedRgdpt">Did he accpet the RGDPT?</param>
        /// <param name="nib">Nib</param>
        /// <param name="nif">Nif</param>
        /// <param name="jobRole">Job role</param>
        /// <param name="jobDescription">Job Description</param>
        /// <param name="managerName">Manager name</param>
        /// <param name="street1">Street 1</param>
        /// <param name="street2">Street 2</param>
        /// <param name="doorNumber">Door number</param>
        /// <param name="city">City</param>
        /// <param name="region">Region</param>
        /// <param name="locale">Locale</param>
        /// <returns>Returns a messanger of the Employee created</returns>
        public string CreateNewEmployee(Employee employee)
        {
            string message = "";

            //string newEmail = firstName.ToLower() + "." + lastName.ToLower() + "@assembly.pt";

            if (!employee.AcceptedRGDPT)
                message += Environment.NewLine + "To be an employee at Assembly you must accept the RGDPD\n";

            if (employee.NIB == 0 || employee.NIF == 0)
                message += Environment.NewLine + "Your NIB or NIF are invalid\n";

            if (message.Length == 0)
            {                
                _employeeRepository.CreateNewEmployee(employee);
                employee.AddressId = _addressServices.CreateNewAddress(employee.Address);

                message = "User created with success";
            }
            else
                message = "There as one or more errors in your information.\n" + message;

            return message;
        }

        public string UpdateEmployee(Employee employee)
        {
            // Verifica se o funcionário existe
            Employee existingEmployee = _employeeRepository.GetEmployeeById(employee.Id);
            if (existingEmployee == null)
            {
                return "User not found\n";
            }
            //Employee updatedEmployee = new Employee(employee.FirstName, employee.MiddleName, employee.LastName, employee.BirtDate, employee.Email, employee.AcceptedRGDPT, employee.AddressId,
            //        employee.NIB, employee.NIF, employee.JobRole, employee.JobDescription, employee.ManagerName);

            // Atualiza os dados do funcionário
            //employee.Id = existingEmployee.Id; Manter o ID do endereço
            _employeeRepository.UpdateEmployee(employee);
            return "User updated with sucess";
        }

        public string DeleteEmployeeById(int id)
        {
            // Verifica se o funcionário existe
            var existingEmployee = _employeeRepository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return "User  not found\n";
            }

            // Deleta o employee
            _employeeRepository.DeleteEmployee(id);
            return "User Deleted with success\n";
        }

        //public Employee GerarDadosFakeCSharp()
        //{
        //    Bogus.Faker f = new Bogus.Faker("pt_PT");
        //    Employee employee = new Employee();
        //    Address address = new Address();
        //    employee.FirstName = f.Person.FirstName;
        //    employee.LastName = f.Person.LastName;
        //    employee.BirtDate = f.Date.Past(50);
        //    employee.Email = f.Person.Email;
        //    address.Street1 = f.Person.Address.Street;
        //    address.DoorNumber = f.IndexFaker;
        //    address.Locale = f.Person.Address.City;
        //    address.City = f.Person.Address.City;
        //    address.Region = f.Person.Address.City;
        //    address.PostalCode = f.Person.Address.ZipCode;
        //    employee.ManagerName = f.Person.FullName;
        //    employee.Address = address;
        //    employee.NIF = Convert.ToInt32(f.Person.Nif());
        //    employee.NIB = Convert.ToInt32(f.Person.Nif());

        //    return employee;
        //}

    }
}
