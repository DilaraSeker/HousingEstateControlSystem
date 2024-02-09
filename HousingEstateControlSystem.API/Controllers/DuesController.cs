using HousingEstateControlSystem.DTOs.Dues;
using HousingEstateControlSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingEstateControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuesController : ControllerBase
    {
        private readonly IDuesService _duesService;

        public DuesController(IDuesService duesService)
        {
            _duesService = duesService;
        }

        [HttpGet]
        public IActionResult GetAllDues()
        {
            var response = _duesService.GetAllDues();
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetDuesById(int id)
        {
            var response = _duesService.GetDuesById(id);
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public IActionResult AddDues([FromBody] DuesAddDtoRequest dues)
        {
            var response = _duesService.AddDues(dues);
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
            return CreatedAtAction(nameof(GetDuesById), new { id = response.Data }, response.Data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDues(int id, [FromBody] DuesUpdateDtoRequest dues)
        {
            _duesService.UpdateDues(dues);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDues(int id)
        {
            _duesService.DeleteDues(id);
            return NoContent();
        }
    }
}
