using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface ICondoService
    {
        ResponseDto<List<CondoDTO>> GetCondos();
        ResponseDto<CondoDTO> GetCondo(int condoId);
        ResponseDto<CondoDTO> CreateCondo(CondoDTO condoDto);
        ResponseDto<CondoDTO> UpdateCondo(int condoId, CondoDTO condoDto);
        ResponseDto<bool> DeleteCondo(int condoId);
    }
}
