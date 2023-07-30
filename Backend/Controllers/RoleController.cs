using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleDal _roleDAL;

        public RoleController(IRoleDal roleDAL)
        {
            _roleDAL = roleDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleDAL.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleDAL.GetById(id);
            if (role == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(Role newRole)
        {
            await _roleDAL.Add(newRole);
            return CreatedAtAction(nameof(GetRoleById), new { id = newRole.Id }, newRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, Role updatedRole)
        {
            var existingRole = await _roleDAL.GetById(id);
            if (existingRole == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingRole.Name = updatedRole.Name;

            // Save the updated role to the database
            await _roleDAL.Update(existingRole);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var roleToDelete = await _roleDAL.GetById(id);
            if (roleToDelete == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            await _roleDAL.Delete(roleToDelete);
            return NoContent();
        }
    }
}