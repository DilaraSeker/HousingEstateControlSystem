using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IUserService
    {
        ResponseDto<List<UserDTO>> GetAllUsers();
        ResponseDto<UserDTO> GetUserById(int userId);
        ResponseDto<int> AddUser(UserAddDtoRequest user);
        void UpdateUser(UserUpdateDtoRequest user);
        void DeleteUser(int userId);
    }
}
