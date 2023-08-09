using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("position")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionDAL _positionDAL;

        public PositionController(IPositionDAL positionDAL)
        {
            _positionDAL = positionDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPositiones()
        {
            var positiones = await _positionDAL.GetAll();
            return Ok(positiones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositionById(int id)
        {
            var position = await _positionDAL.GetById(id);
            if (position == null)
            {
                return NotFound($"Position with ID {id} not found.");
            }

            return Ok(position);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition(Position newPosition)
        {
            await _positionDAL.Add(newPosition);
            return CreatedAtAction(nameof(GetPositionById), new { id = newPosition.Id }, newPosition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(int id, Position updatedPosition)
        {
            var existingPosition = await _positionDAL.GetById(id);
            if (existingPosition == null)
            {
                return NotFound($"Position with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingPosition.Id = updatedPosition.Id;

            // Save the updated role to the database
            await _positionDAL.Update(existingPosition);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            var positionToDelete = await _positionDAL.GetById(id);
            if (positionToDelete == null)
            {
                return NotFound($"Position with ID {id} not found.");
            }

            await _positionDAL.Delete(positionToDelete);
            return NoContent();
        }
    }
}