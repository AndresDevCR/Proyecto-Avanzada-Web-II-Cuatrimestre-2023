using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentDal _departmentDAL;

        public DepartmentController(IDepartmentDal departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentDAL.GetAll();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentDAL.GetById(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department newDepartment)
        {
            await _departmentDAL.Add(newDepartment);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = newDepartment.Id }, newDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department updatedDepartment)
        {
            var existingDepartment = await _departmentDAL.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingDepartment.DepartmentName = updatedDepartment.DepartmentName;

            // Save the updated role to the database
            await _departmentDAL.Update(existingDepartment);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var departmentToDelete = await _departmentDAL.GetById(id);
            if (departmentToDelete == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            await _departmentDAL.Delete(departmentToDelete);
            return NoContent();
        }
    }
}