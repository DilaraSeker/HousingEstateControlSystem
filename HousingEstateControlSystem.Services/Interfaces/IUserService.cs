using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IUserService
    {
        ResponseDto<List<UserDTO>> GetUsers();
        ResponseDto<UserDTO> GetUser(int userId);
        ResponseDto<UserDTO> CreateUser(UserDTO userDto);
        ResponseDto<UserDTO> UpdateUser(int userId, UserDTO userDto);
        ResponseDto<bool> DeleteUser(int userId);
    }
}
