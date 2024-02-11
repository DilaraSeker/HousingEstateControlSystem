using AutoMapper;
using HousingEstateControlSystem.DTOs.Auth;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Services.Mappers
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<RegisterDTO, User>(); 
            CreateMap<LoginDTO, User>(); 
            CreateMap<User, AuthResponseDTO>(); 
        }
    }
}
