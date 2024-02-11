using HousingEstateControlSystem.DTOs.Auth;
using HousingEstateControlSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HousingEstateControlSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            var result = _authService.Login(loginDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO registerDto)
        {
            var result = _authService.Register(registerDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
