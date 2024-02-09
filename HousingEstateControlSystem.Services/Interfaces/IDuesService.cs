using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IDuesService
    {
        ResponseDto<List<DuesDTO>> GetDues();
        ResponseDto<DuesDTO> GetDues(int duesId);
        ResponseDto<DuesDTO> CreateDues(DuesDTO duesDto);
        ResponseDto<DuesDTO> UpdateDues(int duesId, DuesDTO duesDto);
        ResponseDto<bool> DeleteDues(int duesId);
    }
}
