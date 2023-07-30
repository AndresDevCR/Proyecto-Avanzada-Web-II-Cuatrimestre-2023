using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationDAL _locationDAL;

        public LocationController(ILocationDAL locationDAL)
        {
            _locationDAL = locationDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationDAL.GetAll();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var location = await _locationDAL.GetById(id);
            if (location == null)
            {
                return NotFound($"Location with ID {id} not found.");
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(Location newLocation)
        {
            await _locationDAL.Add(newLocation);
            return CreatedAtAction(nameof(GetLocationById), new { id = newLocation.Id }, newLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location updatedLocation)
        {
            var existingLocation = await _locationDAL.GetById(id);
            if (existingLocation == null)
            {
                return NotFound($"Location with ID {id} not found.");
            }

            existingLocation.Name = updatedLocation.Name;
            existingLocation.Building = updatedLocation.Building;
            existingLocation.Address = updatedLocation.Address;
            existingLocation.Active = updatedLocation.Active;
            existingLocation.UpdatedOn = updatedLocation.UpdatedOn;

            await _locationDAL.Update(existingLocation);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var locationToDelete = await _locationDAL.GetById(id);
            if (locationToDelete == null)
            {
                return NotFound($"Location with ID {id} not found.");
            }

            await _locationDAL.Delete(locationToDelete);
            return NoContent();
        }
    }
}
