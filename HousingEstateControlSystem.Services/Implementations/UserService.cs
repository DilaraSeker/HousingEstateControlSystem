using AutoMapper;
using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.DTOs.User;
using HousingEstateControlSystem.Repositories.Models;
using HousingEstateControlSystem.Services.Interfaces;

namespace HousingEstateControlSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public ResponseDto<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                var userDtos = _mapper.Map<List<UserDTO>>(users);
                return ResponseDto<List<UserDTO>>.Success(userDtos);
            }
            catch (Exception ex)
            {
                return ResponseDto<List<UserDTO>>.Fail("Failed to get users.");
            }
        }

        public ResponseDto<UserDTO> GetUserById(int userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);
                if (user == null)
                    return ResponseDto<UserDTO>.Fail("User not found!");

                var userDto = _mapper.Map<UserDTO>(user);
                return ResponseDto<UserDTO>.Success(userDto);
            }
            catch (Exception ex)
            {               
                return ResponseDto<UserDTO>.Fail("Failed to get user details.");
            }
        }

        public ResponseDto<int> AddUser(UserAddDtoRequest user)
        {
            try
            {
                var existingUser = _userRepository.GetUserByEmail(user.Email);
                if (existingUser != null)
                    return ResponseDto<int>.Fail("A user with the same email already exists!");

                var newUser = _mapper.Map<User>(user);
                _userRepository.AddUser(newUser);

                return ResponseDto<int>.Success(newUser.UserId);
            }
            catch (Exception ex)
            {               
                return ResponseDto<int>.Fail("Failed to add new user!");
            }
        }

        public void UpdateUser(UserUpdateDtoRequest user)
        {
            try
            {
                var existingUser = _userRepository.GetUserById(user.UserId);
                if (existingUser == null)
                    throw new Exception("User not found!");

                _mapper.Map(user, existingUser);
                _userRepository.UpdateUser(existingUser);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to update user!");
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                var existingUser = _userRepository.GetUserById(userId);
                if (existingUser == null)
                    throw new Exception("User not found!");

                _userRepository.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to delete user!");
            }
        }
    }
}
