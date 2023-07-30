using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryDAL _inventoryDAL;

        public InventoryController(IInventoryDAL inventoryDAL)
        {
            _inventoryDAL = inventoryDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventories()
        {
            var inventories = await _inventoryDAL.GetAll();
            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            var inventory = await _inventoryDAL.GetById(id);
            if (inventory == null)
            {
                return NotFound($"Inventory with ID {id} not found.");
            }

            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventory(Inventory newInventory)
        {
            await _inventoryDAL.Add(newInventory);
            return CreatedAtAction(nameof(GetInventoryById), new { id = newInventory.Id }, newInventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, Inventory updatedInventory)
        {
            var existingInventory = await _inventoryDAL.GetById(id);
            if (existingInventory == null)
            {
                return NotFound($"Inventory with ID {id} not found.");
            }

            existingInventory.ProductName = updatedInventory.ProductName;
            existingInventory.AvailableQuantity = updatedInventory.AvailableQuantity;
            existingInventory.Description = updatedInventory.Description;
            existingInventory.EntryDate = updatedInventory.EntryDate;
            existingInventory.UpdatedAt = updatedInventory.UpdatedAt;

            await _inventoryDAL.Update(existingInventory);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var inventoryToDelete = await _inventoryDAL.GetById(id);
            if (inventoryToDelete == null)
            {
                return NotFound($"Inventory with ID {id} not found.");
            }

            await _inventoryDAL.Delete(inventoryToDelete);
            return NoContent();
        }
    }
}
