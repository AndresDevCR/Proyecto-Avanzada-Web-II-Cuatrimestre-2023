using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserDAL _userDAL;

        public UserController(IUserDAL userDAL)
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

            updatedUser.Id = id; // Asegurarse de que el ID del usuario actualizado sea el mismo que el ID de la URL.
            await _userDAL.Update(updatedUser);
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
