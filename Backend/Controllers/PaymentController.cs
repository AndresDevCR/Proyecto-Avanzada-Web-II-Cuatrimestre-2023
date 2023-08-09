using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentDAL _paymentDAL;

        public PaymentController(IPaymentDAL paymentDAL)
        {
            _paymentDAL = paymentDAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentDAL.GetAll();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _paymentDAL.GetById(id);
            if (payment == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(Payment newPayment)
        {
            await _paymentDAL.Add(newPayment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = newPayment.Id }, newPayment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, Payment updatedPayment)
        {
            var existingPayment = await _paymentDAL.GetById(id);
            if (existingPayment == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            existingPayment.EmployeeId = updatedPayment.EmployeeId;
            existingPayment.BiweeklySalary = updatedPayment.BiweeklySalary;
            existingPayment.DailySalary = updatedPayment.DailySalary;
            existingPayment.Subsidy = updatedPayment.Subsidy;
            existingPayment.HourRate = updatedPayment.HourRate;
            existingPayment.ExtraTimeValue = updatedPayment.ExtraTimeValue;
            existingPayment.ExtraTime = updatedPayment.ExtraTime;
            existingPayment.ExtraTimeTotal = updatedPayment.ExtraTimeTotal;
            existingPayment.MedicalLeaveDays = updatedPayment.MedicalLeaveDays;
            existingPayment.NotPayedLeaveDays = updatedPayment.NotPayedLeaveDays;
            existingPayment.GrossPayment = updatedPayment.GrossPayment;
            existingPayment.GrossPaymentSocialDeduction = updatedPayment.GrossPaymentSocialDeduction;
            existingPayment.PaymentAdvance = updatedPayment.PaymentAdvance;
            existingPayment.DeductionTotal = updatedPayment.DeductionTotal;
            existingPayment.NetPayment = updatedPayment.NetPayment;
            existingPayment.NetPaymentDollar = updatedPayment.NetPaymentDollar;
            existingPayment.InsPayroll = updatedPayment.InsPayroll;
            existingPayment.UpdatedAt = updatedPayment.UpdatedAt;

            await _paymentDAL.Update(existingPayment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var paymentToDelete = await _paymentDAL.GetById(id);
            if (paymentToDelete == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            await _paymentDAL.Delete(paymentToDelete);
            return NoContent();
        }
    }
}
