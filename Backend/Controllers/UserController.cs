using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserDal _userDAL;

        public UserController(IUserDal userDAL)
        {
            _userDAL = userDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userDAL.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userDAL.GetById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User newUser)
        {
            await _userDAL.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            var existingUser = await _userDAL.GetById(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            // Update all properties of the existing user with the values from the updated user
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.PasswordResetCode = updatedUser.PasswordResetCode;
            existingUser.IsActive = updatedUser.IsActive;
            existingUser.ProfileId = updatedUser.ProfileId;
            existingUser.CompanyId = updatedUser.CompanyId;
            existingUser.CompanyStartDate = updatedUser.CompanyStartDate;
            existingUser.RoleId = updatedUser.RoleId;
            existingUser.CreatedAt = updatedUser.CreatedAt;
            existingUser.UpdatedAt = updatedUser.UpdatedAt;
            existingUser.LastLogin = updatedUser.LastLogin;

            // Save the updated user to the database
            await _userDAL.Update(existingUser);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _userDAL.GetById(id);
            if (userToDelete == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userDAL.Delete(userToDelete);
            return NoContent();
        }
    }
}
