using HousingEstateControlSystem.DTOs.Auth;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDTO Login(LoginDTO loginDto);
        AuthResponseDTO Register(RegisterDTO registerDto);
    }
}