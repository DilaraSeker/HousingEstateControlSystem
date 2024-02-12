using HousingEstateControlSystem.DTOs.Auth;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDTO Register(RegisterDTO registerDto);
        AuthResponseDTO Login(LoginDTO loginDto);
    }
}
