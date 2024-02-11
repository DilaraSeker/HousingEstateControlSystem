using AutoMapper;
using HousingEstateControlSystem.DTOs.Bill;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Services.Mappers
{
    public class BillMapper : Profile
    {
        public BillMapper()
        {
            CreateMap<Bill, BillDTO>().ReverseMap();
            CreateMap<BillAddDtoRequest, Bill>();
            CreateMap<BillUpdateDtoRequest, Bill>();
        }
    }
}
