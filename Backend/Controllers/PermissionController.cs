using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("permission")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionDAL _permissionDAL;

        public PermissionController(IPermissionDAL permissionDAL)
        {
            _permissionDAL = permissionDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissiones()
        {
            var permissiones = await _permissionDAL.GetAll();
            return Ok(permissiones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            var permission = await _permissionDAL.GetById(id);
            if (permission == null)
            {
                return NotFound($"Permission with ID {id} not found.");
            }

            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission(Permission newPermission)
        {
            await _permissionDAL.Add(newPermission);
            return CreatedAtAction(nameof(GetPermissionById), new { id = newPermission.Id }, newPermission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id, Permission updatedPermission)
        {
            var existingPermission = await _permissionDAL.GetById(id);
            if (existingPermission == null)
            {
                return NotFound($"Permission with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingPermission.Id = updatedPermission.Id;

            // Save the updated role to the database
            await _permissionDAL.Update(existingPermission);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var permissionToDelete = await _permissionDAL.GetById(id);
            if (permissionToDelete == null)
            {
                return NotFound($"Permission with ID {id} not found.");
            }

            await _permissionDAL.Delete(permissionToDelete);
            return NoContent();
        }
    }
}