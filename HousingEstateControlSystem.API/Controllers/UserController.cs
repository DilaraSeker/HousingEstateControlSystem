using Microsoft.AspNetCore.Mvc;
using HousingEstateControlSystem.Services.Interfaces;
using HousingEstateControlSystem.DTOs.User;

namespace HousingEstateControlSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var response = _userService.GetAllUsers();
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in GetAllUsers: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
            try
            {
                var response = _userService.AddUser(user);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
