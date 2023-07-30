using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/supplier")]
    public class SupplierController: ControllerBase
    {
        private readonly ISupplierDal _supplierDal;

        public SupplierController(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var roles = await _supplierDal.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var role = await _supplierDal.GetById(id);
            if (role == null)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(Supplier newSupplier)
        {
            await _supplierDal.Add(newSupplier);
            return CreatedAtAction(nameof(GetSupplierById), new { id = newSupplier.Id }, newSupplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, Supplier updatedSupplier)
        {
            var existingSupplier = await _supplierDal.GetById(id);
            if (existingSupplier == null)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingSupplier.Id= updatedSupplier.Id;

            // Save the updated role to the database
            await _supplierDal.Update(existingSupplier);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var roleToDelete = await _supplierDal.GetById(id);
            if (roleToDelete == null)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }

            await _supplierDal.Delete(roleToDelete);
            return NoContent();
        }
    }
}