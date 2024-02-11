
namespace HousingEstateControlSystem.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public string Username { get; set; } 
        public string Email { get; set; } 
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}