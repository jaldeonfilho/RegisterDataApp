using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        public IClientServices _clientServices;
        
        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [HttpGet]
        public IActionResult GetClientById(int id)
        {
            Client client = _clientServices.GetClientById(id);
            return Ok(client);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllClient()
        {
            List<Client> clients = _clientServices.GetAllClients();
            return Ok(clients);
        }
        [HttpPost]
        public IActionResult CreateClient(Client client)
        {
            string msg = _clientServices.CreateNewClient(client);
            return Ok(msg);
        }
        [HttpPut]
        public IActionResult UpdateClient(Client client)
        {
            string msg = _clientServices.UpdateClient(client);
            return Ok(msg);
        }
        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            string msg = _clientServices.DeleteClient(id);
            return Ok(msg);
        }

    }
}
