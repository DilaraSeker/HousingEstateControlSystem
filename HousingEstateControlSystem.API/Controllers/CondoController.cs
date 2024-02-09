using HousingEstateControlSystem.DTOs.Condo;
using HousingEstateControlSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingEstateControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondoController : ControllerBase
    {
        private readonly ICondoService _condoService;

        public CondoController(ICondoService condoService)
        {
            _condoService = condoService;
        }

        [HttpGet]
        public IActionResult GetAllCondos()
        {
            var response = _condoService.GetAllCondos();
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCondoById(int id)
        {
            var response = _condoService.GetCondoById(id);
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public IActionResult AddCondo([FromBody] CondoAddDtoRequest condo)
        {
            var response = _condoService.AddCondo(condo);
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
            return CreatedAtAction(nameof(GetCondoById), new { id = response.Data }, response.Data);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCondo(int id, [FromBody] CondoUpdateDtoRequest condo)
        {
            _condoService.UpdateCondo(condo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCondo(int id)
        {
            _condoService.DeleteCondo(id);
            return NoContent();
        }
    }
}
