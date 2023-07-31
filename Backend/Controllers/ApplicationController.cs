using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/application")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationDal _applicationDAL;

        public ApplicationController(IApplicationDal applicationDAL)
        {
            _applicationDAL = applicationDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await _applicationDAL.GetAll();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var application = await _applicationDAL.GetById(id);
            if (application == null)
            {
                return NotFound($"Application with ID {id} not found.");
            }

            return Ok(application);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(Application newApplication)
        {
            await _applicationDAL.Add(newApplication);
            return CreatedAtAction(nameof(GetApplicationById), new { id = newApplication.Id }, newApplication);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, Application updatedApplication)
        {
            var existingApplication = await _applicationDAL.GetById(id);
            if (existingApplication == null)
            {
                return NotFound($"Application with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingApplication.Name = updatedApplication.Name;

            // Save the updated role to the database
            await _applicationDAL.Update(existingApplication);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var applicationToDelete = await _applicationDAL.GetById(id);
            if (applicationToDelete == null)
            {
                return NotFound($"Application with ID {id} not found.");
            }

            await _applicationDAL.Delete(applicationToDelete);
            return NoContent();
        }
    }
}