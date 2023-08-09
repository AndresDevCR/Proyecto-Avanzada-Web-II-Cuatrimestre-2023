using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceDAL _invoiceDAL;

        public InvoiceController(IInvoiceDAL invoiceDAL)
        {
            _invoiceDAL = invoiceDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceDAL.GetAll();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _invoiceDAL.GetById(id);
            if (invoice == null)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }

            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(Invoice newInvoice)
        {
            await _invoiceDAL.Add(newInvoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = newInvoice.Id }, newInvoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, Invoice updatedInvoice)
        {
            var existingInvoice = await _invoiceDAL.GetById(id);
            if (existingInvoice == null)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }

            existingInvoice.QuotationId = updatedInvoice.QuotationId;
            existingInvoice.SupplierId = updatedInvoice.SupplierId;
            existingInvoice.IssueDate = updatedInvoice.IssueDate;
            existingInvoice.ExpirationDate = updatedInvoice.ExpirationDate;
            existingInvoice.InvoiceNumber = updatedInvoice.InvoiceNumber;
            existingInvoice.DollarValue = updatedInvoice.DollarValue;
            existingInvoice.TotalColon = updatedInvoice.TotalColon;
            existingInvoice.TotalDollar = updatedInvoice.TotalDollar;
            existingInvoice.UpdatedAt = updatedInvoice.UpdatedAt;

            await _invoiceDAL.Update(existingInvoice);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoiceToDelete = await _invoiceDAL.GetById(id);
            if (invoiceToDelete == null)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }

            await _invoiceDAL.Delete(invoiceToDelete);
            return NoContent();
        }
    }
}
