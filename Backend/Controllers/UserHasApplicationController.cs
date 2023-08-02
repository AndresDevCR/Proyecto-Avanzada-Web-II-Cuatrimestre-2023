using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("userHasApplication")]
    public class UserHasApplicationController: ControllerBase
    {
        private readonly IUserHasApplicationDal _userHasApplicationDal;

        public UserHasApplicationController(IUserHasApplicationDal userHasApplicationDal)
        {
            _userHasApplicationDal = userHasApplicationDal;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserHasApplications()
        {
            var userHasApplications = await _userHasApplicationDal.GetAll();
            return Ok(userHasApplications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserHasApplicationById(int id)
        {
            var userHasApplication = await _userHasApplicationDal.GetById(id);
            if (userHasApplication == null)
            {
                return NotFound($"UserHasApplication with ID {id} not found.");
            }

            return Ok(userHasApplication);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserHasApplication(UserHasApplication newUserHasApplication)
        {
            await _userHasApplicationDal.Add(newUserHasApplication);
            return CreatedAtAction(nameof(GetUserHasApplicationById), new { id = newUserHasApplication.UserId }, newUserHasApplication);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserHasApplication(int id, UserHasApplication updatedUserHasApplication)
        {
            var existingUserHasApplication = await _userHasApplicationDal.GetById(id);
            if (existingUserHasApplication == null)
            {
                return NotFound($"UserHasApplication with ID {id} not found.");
            }

            // Update all properties of the existing userHasApplication with the values from the updated userHasApplication
            existingUserHasApplication.UserId= updatedUserHasApplication.UserId;

            // Save the updated userHasApplication to the database
            await _userHasApplicationDal.Update(existingUserHasApplication);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHasApplication(int id)
        {
            var userHasApplicationToDelete = await _userHasApplicationDal.GetById(id);
            if (userHasApplicationToDelete == null)
            {
                return NotFound($"UserHasApplication with ID {id} not found.");
            }

            await _userHasApplicationDal.Delete(userHasApplicationToDelete);
            return NoContent();
        }
    }
}