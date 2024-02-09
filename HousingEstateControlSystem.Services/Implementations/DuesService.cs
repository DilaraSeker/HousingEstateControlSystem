using AutoMapper;
using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs.Dues;
using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;
using HousingEstateControlSystem.Services.Interfaces;

namespace HousingEstateControlSystem.Services.Implementations
{
    public class DuesService : IDuesService
    {
        private readonly IMapper _mapper;
        private readonly IDuesRepository _duesRepository;

        public DuesService(IMapper mapper, IDuesRepository duesRepository)
        {
            _mapper = mapper;
            _duesRepository = duesRepository;
        }

        public ResponseDto<List<DuesDTO>> GetAllDues()
        {
            var dues = _duesRepository.GetAllDues();
            var duesDto = _mapper.Map<List<DuesDTO>>(dues);
            return ResponseDto<List<DuesDTO>>.Success(duesDto);
        }

        public ResponseDto<DuesDTO> GetDuesById(int duesId)
        {
            var dues = _duesRepository.GetDuesById(duesId);
            if (dues == null)
            {
                return ResponseDto<DuesDTO>.Fail("Dues not found!");
            }
            var duesDto = _mapper.Map<DuesDTO>(dues);
            return ResponseDto<DuesDTO>.Success(duesDto);
        }

        public ResponseDto<int> AddDues(DuesAddDtoRequest dues)
        {
            var newDues = _mapper.Map<Dues>(dues);
            _duesRepository.AddDues(newDues);
            return ResponseDto<int>.Success(newDues.DuesId);
        }

        public void UpdateDues(DuesUpdateDtoRequest dues)
        {
            var existingDues = _duesRepository.GetDuesById(dues.DuesId);
            if (existingDues != null)
            {
                _mapper.Map(dues, existingDues);
                _duesRepository.UpdateDues(existingDues);
            }
        }

        public void DeleteDues(int duesId)
        {
            _duesRepository.DeleteDues(duesId);
        }
    }
}
