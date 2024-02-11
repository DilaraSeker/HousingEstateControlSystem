using AutoMapper;
using HousingEstateControlSystem.DTOs.Condo;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Services.Mappers
{
    public class CondoMapper : Profile
    {
        public CondoMapper()
        {
            CreateMap<Condo, CondoDTO>().ReverseMap(); 
            CreateMap<CondoAddDtoRequest, Condo>();
            CreateMap<CondoUpdateDtoRequest, Condo>();
        }
    }
}
