using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressDal _addressDAL;

        public AddressController(IAddressDal addressDAL)
        {
            _addressDAL = addressDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _addressDAL.GetAll();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _addressDAL.GetById(id);
            if (address == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }

            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(Address newAddress)
        {
            await _addressDAL.Add(newAddress);
            return CreatedAtAction(nameof(GetAddressById), new { id = newAddress.Id }, newAddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, Address updatedAddress)
        {
            var existingAddress = await _addressDAL.GetById(id);
            if (existingAddress == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingAddress.City = updatedAddress.City;

            // Save the updated role to the database
            await _addressDAL.Update(existingAddress);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var addressToDelete = await _addressDAL.GetById(id);
            if (addressToDelete == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }

            await _addressDAL.Delete(addressToDelete);
            return NoContent();
        }
    }
}