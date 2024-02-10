using HousingEstateControlSystem.DTOs;
using HousingEstateControlSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingEstateControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            try
            {
                var payment = _paymentService.GetPaymentById(id);
                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            try
            {
                var payments = _paymentService.GetAllPayments();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddPayment([FromBody] PaymentAddDTORequest paymentAddDTO)
        {
            try
            {
                var addedPayment = _paymentService.AddPayment(paymentAddDTO);
                return CreatedAtAction(nameof(GetPaymentById), new { id = addedPayment.PaymentId }, addedPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, [FromBody] PaymentUpdateDTORequest paymentUpdateDTO)
        {
            try
            {
                _paymentService.UpdatePayment(paymentUpdateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            try
            {
                _paymentService.DeletePayment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
