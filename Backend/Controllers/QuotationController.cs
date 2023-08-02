using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("quotation")]
    public class QuotationController: ControllerBase
    {
        private readonly IQuotationDal _quotationDal;

        public QuotationController(IQuotationDal quotationDal)
        {
            _quotationDal = quotationDal;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuotations()
        {
            var quotations = await _quotationDal.GetAll();
            return Ok(quotations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuotationById(int id)
        {
            var quotation = await _quotationDal.GetById(id);
            if (quotation == null)
            {
                return NotFound($"Quotation with ID {id} not found.");
            }

            return Ok(quotation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuotation(Quotation newQuotation)
        {
            await _quotationDal.Add(newQuotation);
            return CreatedAtAction(nameof(GetQuotationById), new { id = newQuotation.Id }, newQuotation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuotation(int id, Quotation updatedQuotation)
        {
            var existingQuotation = await _quotationDal.GetById(id);
            if (existingQuotation == null)
            {
                return NotFound($"Quotation with ID {id} not found.");
            }

            // Update all properties of the existing quotation with the values from the updated quotation
            existingQuotation.Id= updatedQuotation.Id;

            // Save the updated quotation to the database
            await _quotationDal.Update(existingQuotation);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotation(int id)
        {
            var quotationToDelete = await _quotationDal.GetById(id);
            if (quotationToDelete == null)
            {
                return NotFound($"Quotation with ID {id} not found.");
            }

            await _quotationDal.Delete(quotationToDelete);
            return NoContent();
        }
    }
}