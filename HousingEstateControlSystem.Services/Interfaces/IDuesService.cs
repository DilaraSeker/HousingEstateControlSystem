using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IDuesService
    {
        ResponseDto<List<DuesDTO>> GetAllDues();
        ResponseDto<DuesDTO> GetDuesById(int duesId);
        ResponseDto<int> AddDues(DuesAddDtoRequest dues);
        void UpdateDues(DuesUpdateDtoRequest dues);
        void DeleteDues(int duesId);
    }
}
