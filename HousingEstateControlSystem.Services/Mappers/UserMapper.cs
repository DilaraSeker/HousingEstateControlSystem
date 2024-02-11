using AutoMapper;
using HousingEstateControlSystem.DTOs.User;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Services.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserAddDtoRequest, User>();
            CreateMap<UserUpdateDtoRequest, User>();



        }
    }
}
