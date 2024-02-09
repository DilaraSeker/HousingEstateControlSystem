using AutoMapper;
using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs.Condo;
using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;
using HousingEstateControlSystem.Services.Interfaces;

namespace HousingEstateControlSystem.Services.Implementations
{
    public class CondoService : ICondoService
    {
        private readonly IMapper _mapper;
        private readonly ICondoRepository _condoRepository;

        public CondoService(IMapper mapper, ICondoRepository condoRepository)
        {
            _mapper = mapper;
            _condoRepository = condoRepository;
        }

        public ResponseDto<List<CondoDTO>> GetAllCondos()
        {
            var condos = _condoRepository.GetAllCondos();
            var condoDtos = _mapper.Map<List<CondoDTO>>(condos);
            return ResponseDto<List<CondoDTO>>.Success(condoDtos);
        }

        public ResponseDto<CondoDTO> GetCondoById(int condoId)
        {
            var condo = _condoRepository.GetCondoById(condoId);
            if (condo == null)
            {
                return ResponseDto<CondoDTO>.Fail("Condo not found!");
            }
            var condoDto = _mapper.Map<CondoDTO>(condo);
            return ResponseDto<CondoDTO>.Success(condoDto);
        }

        public ResponseDto<int> AddCondo(CondoAddDtoRequest condo)
        {
            var newCondo = _mapper.Map<Condo>(condo);
            _condoRepository.AddCondo(newCondo);
            return ResponseDto<int>.Success(newCondo.CondoId);
        }

        public void UpdateCondo(CondoUpdateDtoRequest condo)
        {
            var existingCondo = _condoRepository.GetCondoById(condo.CondoId);
            if (existingCondo != null)
            {
                _mapper.Map(condo, existingCondo);
                _condoRepository.UpdateCondo(existingCondo);
            }
        }

        public void DeleteCondo(int condoId)
        {
            _condoRepository.DeleteCondo(condoId);
        }
    }
}
