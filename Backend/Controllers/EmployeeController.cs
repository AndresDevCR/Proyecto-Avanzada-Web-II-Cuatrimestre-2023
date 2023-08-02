using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDal _employeeDAL;

        public EmployeeController(IEmployeeDal employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeDAL.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeDAL.GetById(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee newEmployee)
        {
            await _employeeDAL.Add(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var existingEmployee = await _employeeDAL.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingEmployee.EmployeeName = updatedEmployee.EmployeeName;

            // Save the updated role to the database
            await _employeeDAL.Update(existingEmployee);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employeeToDelete = await _employeeDAL.GetById(id);
            if (employeeToDelete == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            await _employeeDAL.Delete(employeeToDelete);
            return NoContent();
        }
    }
}