using Microsoft.AspNetCore.Mvc;
using HousingEstateControlSystem.Services.Interfaces;
using HousingEstateControlSystem.DTOs.User;
using HousingEstateControlSystem.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using HousingEstateControlSystem.DTOs;
using HousingEstateControlSystem.DTOs.Auth;

namespace HousingEstateControlSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new User
                {
                    FullName = model.Email,
                    Email = model.Email,
                    UserName = model.Email // E-posta adresini kullanıcı adı olarak atama
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Registration successful" });
                }
                else
                {
                    return BadRequest(new { message = "Registration failed", errors = result.Errors });
                }
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda logla
                Console.WriteLine($"Error in Register: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var response = _userService.GetAllUsers();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var response = _userService.GetUserById(userId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public IActionResult AddUser(UserAddDtoRequest user)
        {
            var response = _userService.AddUser(user);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(UserUpdateDtoRequest user)
        {
            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
            return NoContent();
        }
    }
}
