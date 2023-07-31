using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/vacation")]
    public class VacationController: ControllerBase
    {
        private readonly IVacationDal _vacationDal;

        public VacationController(IVacationDal vacationDal)
        {
            _vacationDal = vacationDal;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacations()
        {
            var vacations = await _vacationDal.GetAll();
            return Ok(vacations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacationById(int id)
        {
            var vacation = await _vacationDal.GetById(id);
            if (vacation == null)
            {
                return NotFound($"Vacation with ID {id} not found.");
            }

            return Ok(vacation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacation(Vacation newVacation)
        {
            await _vacationDal.Add(newVacation);
            return CreatedAtAction(nameof(GetVacationById), new { id = newVacation.Id }, newVacation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVacation(int id, Vacation updatedVacation)
        {
            var existingVacation = await _vacationDal.GetById(id);
            if (existingVacation == null)
            {
                return NotFound($"Vacation with ID {id} not found.");
            }

            // Update all properties of the existing vacation with the values from the updated vacation
            existingVacation.Id= updatedVacation.Id;

            // Save the updated vacation to the database
            await _vacationDal.Update(existingVacation);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacation(int id)
        {
            var vacationToDelete = await _vacationDal.GetById(id);
            if (vacationToDelete == null)
            {
                return NotFound($"Vacation with ID {id} not found.");
            }

            await _vacationDal.Delete(vacationToDelete);
            return NoContent();
        }
    }
}