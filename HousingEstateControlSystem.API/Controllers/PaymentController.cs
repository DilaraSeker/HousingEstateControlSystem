using HousingEstateControlSystem.DTOs;
using HousingEstateControlSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingEstateControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult AddPayment(PaymentAddDtoRequest paymentDto)
        {
            try
            {
                _paymentService.AddPayment(paymentDto);
                return Ok("Payment added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            try
            {
                IEnumerable<PaymentDTO> payments = _paymentService.GetAllPayments();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetPaymentsByUserId(string userId)
        {
            try
            {
                IEnumerable<PaymentDTO> payments = _paymentService.GetPaymentsByUserId(userId);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("totalAmount/{userId}")]
        public IActionResult GetTotalAmountPaidByUser(string userId)
        {
            try
            {
                decimal totalAmount = _paymentService.GetTotalAmountPaidByUser(userId);
                return Ok(totalAmount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}
