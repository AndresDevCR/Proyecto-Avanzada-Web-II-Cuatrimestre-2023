using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("enterprise")]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseDAL _enterpriseDAL; 

        public EnterpriseController(IEnterpriseDAL enterpriseDAL) 
        {
            _enterpriseDAL = enterpriseDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnterprises() 
        {
            var enterprises = await _enterpriseDAL.GetAll(); 
            return Ok(enterprises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnterpriseById(int id)
        {
            var enterprise = await _enterpriseDAL.GetById(id);
            if (enterprise == null)
            {
                return NotFound($"Enterprise with ID {id} not found.");
            }

            return Ok(enterprise);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnterprise(Enterprise newEnterprise)
        {
            await _enterpriseDAL.Add(newEnterprise);
            return CreatedAtAction(nameof(GetEnterpriseById), new { id = newEnterprise.Id }, newEnterprise);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnterprise(int id, Enterprise updatedEnterprise) 
        {
            var existingEnterprise = await _enterpriseDAL.GetById(id); 
            if (existingEnterprise == null)
            {
                return NotFound($"Enterprise with ID {id} not found.");
            }

            existingEnterprise.EnterpriseName = updatedEnterprise.EnterpriseName;

            await _enterpriseDAL.Update(existingEnterprise); 

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise(int id) 
        {
            var enterpriseToDelete = await _enterpriseDAL.GetById(id);
            if (enterpriseToDelete == null)
            {
                return NotFound($"Enterprise with ID {id} not found.");
            }

            await _enterpriseDAL.Delete(enterpriseToDelete);
            return NoContent();
        }
    }
}
