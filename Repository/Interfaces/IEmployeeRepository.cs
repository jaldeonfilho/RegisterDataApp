using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        public void CreateNewEmployee(Employee employee);
        public Employee GetEmployeeById(int id);
        public List<Employee> GetAll();
        public List<Employee> GetAll2();
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(int id);
    }
}
