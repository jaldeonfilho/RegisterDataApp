using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices) 
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _employeeServices.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllEmployees()
        {
            List<Employee> employees = _employeeServices.GetAllEmployee();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            string msg = _employeeServices.CreateNewEmployee(employee);
            return Ok(msg);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            string messenger = _employeeServices.UpdateEmployee(employee);
            return Ok(messenger);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeServices.DeleteEmployeeById(id);
            return Ok();
        }


    }
}
