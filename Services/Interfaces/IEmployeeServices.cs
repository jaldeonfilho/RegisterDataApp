using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeServices
    {
        public Employee GetEmployeeById(int id);
        public List<Employee> GetAllEmployee();
        public string CreateNewEmployee(Employee employee);
        public string UpdateEmployeeById(Employee employee);
        public string DeleteEmployeeById(int id);

    }
}
