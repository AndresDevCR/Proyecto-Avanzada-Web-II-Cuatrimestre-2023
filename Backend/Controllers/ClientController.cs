using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientDal _clientDAL;

        public ClientController(IClientDal clientDAL)
        {
            _clientDAL = clientDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientDAL.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientDAL.GetById(id);
            if (client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client newClient)
        {
            await _clientDAL.Add(newClient);
            return CreatedAtAction(nameof(GetClientById), new { id = newClient.Id }, newClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client updatedClient)
        {
            var existingClient = await _clientDAL.GetById(id);
            if (existingClient == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingClient.ClientName = updatedClient.ClientName;

            // Save the updated role to the database
            await _clientDAL.Update(existingClient);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var clientToDelete = await _clientDAL.GetById(id);
            if (clientToDelete == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            await _clientDAL.Delete(clientToDelete);
            return NoContent();
        }
    }
}