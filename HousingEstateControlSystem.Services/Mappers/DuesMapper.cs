using AutoMapper;
using HousingEstateControlSystem.DTOs.Dues;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Services.Mappers
{
    public class DuesMapper : Profile
    {
        public DuesMapper()
        {
            CreateMap<Dues, DuesDTO>().ReverseMap();
            CreateMap<DuesAddDtoRequest, Dues>();
            CreateMap<DuesUpdateDtoRequest, Dues>();
        }
    }
}
