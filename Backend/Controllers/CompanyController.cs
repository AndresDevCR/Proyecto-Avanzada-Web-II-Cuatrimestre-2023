using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyDal _companyDAL;

        public CompanyController(ICompanyDal companyDAL)
        {
            _companyDAL = companyDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyDAL.GetAll();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyDAL.GetById(id);
            if (company == null)
            {
                return NotFound($"Company with ID {id} not found.");
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company newCompany)
        {
            await _companyDAL.Add(newCompany);
            return CreatedAtAction(nameof(GetCompanyById), new { id = newCompany.Id }, newCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, Company updatedCompany)
        {
            var existingCompany = await _companyDAL.GetById(id);
            if (existingCompany == null)
            {
                return NotFound($"Company with ID {id} not found.");
            }

            // Update all properties of the existing role with the values from the updated role
            existingCompany.Name= updatedCompany.Name;

            // Save the updated role to the database
            await _companyDAL.Update(existingCompany);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var companyToDelete = await _companyDAL.GetById(id);
            if (companyToDelete == null)
            {
                return NotFound($"Company with ID {id} not found.");
            }

            await _companyDAL.Delete(companyToDelete);
            return NoContent();
        }
    }
}