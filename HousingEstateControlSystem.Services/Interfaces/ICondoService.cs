using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs.Condo;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface ICondoService
    {
        ResponseDto<List<CondoDTO>> GetAllCondos();
        ResponseDto<CondoDTO> GetCondoById(int condoId);
        ResponseDto<int> AddCondo(CondoAddDtoRequest condo);
        void UpdateCondo(CondoUpdateDtoRequest condo);
        void DeleteCondo(int condoId);
    }
}
