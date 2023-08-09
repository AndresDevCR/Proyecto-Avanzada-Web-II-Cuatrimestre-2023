using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("humanresource")]
    public class HumanResourceController : ControllerBase
    {
        private readonly IHumanResourceDAL _humanResourceDAL;

        public HumanResourceController(IHumanResourceDAL humanResourceDAL)
        {
            _humanResourceDAL = humanResourceDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHumanResources()
        {
            var humanResources = await _humanResourceDAL.GetAll();
            return Ok(humanResources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHumanResourceById(int id)
        {
            var humanResource = await _humanResourceDAL.GetById(id);
            if (humanResource == null)
            {
                return NotFound($"HumanResource with ID {id} not found.");
            }

            return Ok(humanResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHumanResource(HumanResource newHumanResource)
        {
            await _humanResourceDAL.Add(newHumanResource);
            return CreatedAtAction(nameof(GetHumanResourceById), new { id = newHumanResource.Id }, newHumanResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHumanResource(int id, HumanResource updatedHumanResource)
        {
            var existingHumanResource = await _humanResourceDAL.GetById(id);
            if (existingHumanResource == null)
            {
                return NotFound($"HumanResource with ID {id} not found.");
            }

            existingHumanResource.EmployeeName = updatedHumanResource.EmployeeName;
            existingHumanResource.Phone = updatedHumanResource.Phone;
            existingHumanResource.Email = updatedHumanResource.Email;
            existingHumanResource.EntryDate = updatedHumanResource.EntryDate;
            existingHumanResource.Salary = updatedHumanResource.Salary;
            existingHumanResource.Position = updatedHumanResource.Position;
            existingHumanResource.Department = updatedHumanResource.Department;
            existingHumanResource.Schedule = updatedHumanResource.Schedule;
            existingHumanResource.RestDays = updatedHumanResource.RestDays;
            existingHumanResource.VacationDays = updatedHumanResource.VacationDays;
            existingHumanResource.UpdatedAt = updatedHumanResource.UpdatedAt;

            await _humanResourceDAL.Update(existingHumanResource);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHumanResource(int id)
        {
            var humanResourceToDelete = await _humanResourceDAL.GetById(id);
            if (humanResourceToDelete == null)
            {
                return NotFound($"HumanResource with ID {id} not found.");
            }

            await _humanResourceDAL.Delete(humanResourceToDelete);
            return NoContent();
        }
    }
}
