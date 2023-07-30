using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/role_has_permission")]
    public class RoleHasPermissionController: ControllerBase
    {
        private readonly IRoleHasPermissionDal _roleHasPermissionDal;

        public RoleHasPermissionController(IRoleHasPermissionDal roleHasPermissionDal)
        {
            _roleHasPermissionDal = roleHasPermissionDal;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleHasPermissionDal.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleHasPermissionDal.GetById(id);
            if (role == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleHasPermission newRole)
        {
            await _roleHasPermissionDal.Add(newRole);
            return CreatedAtAction(nameof(GetRoleById), new { id = newRole.RoleId }, newRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, Role updatedRole)
        {
            var existingRole = await _roleHasPermissionDal.GetById(id);
            if (existingRole == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingRole.RoleId = updatedRole.Id;

            // Save the updated role to the database
            await _roleHasPermissionDal.Update(existingRole);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var roleToDelete = await _roleHasPermissionDal.GetById(id);
            if (roleToDelete == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }

            await _roleHasPermissionDal.Delete(roleToDelete);
            return NoContent();
        }
    }
}