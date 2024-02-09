using HousingEstateControlSystem.DTOs.Bill;
using HousingEstateControlSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingEstateControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        public IActionResult GetAllBills()
        {
            var response = _billService.GetAllBills();
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetBillById(int id)
        {
            var response = _billService.GetBillById(id);
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public IActionResult AddBill([FromBody] BillAddDtoRequest bill)
        {
            var response = _billService.AddBill(bill);
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
            return CreatedAtAction(nameof(GetBillById), new { id = response.Data }, response.Data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBill(int id, [FromBody] BillUpdateDtoRequest bill)
        {
            _billService.UpdateBill(bill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBill(int id)
        {
            _billService.DeleteBill(id);
            return NoContent();
        }
    }
}
