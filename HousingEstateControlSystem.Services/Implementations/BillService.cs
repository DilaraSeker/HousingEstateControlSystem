using AutoMapper;
using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs.Bill;
using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;
using HousingEstateControlSystem.Services.Interfaces;

namespace HousingEstateControlSystem.Services.Implementations
{
    public class BillService : IBillService
    {
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;

        public BillService(IMapper mapper, IBillRepository billRepository)
        {
            _mapper = mapper;
            _billRepository = billRepository;
        }

        public ResponseDto<List<BillDTO>> GetAllBills()
        {
            var bills = _billRepository.GetAllBills();
            var billDtos = _mapper.Map<List<BillDTO>>(bills);
            return ResponseDto<List<BillDTO>>.Success(billDtos);
        }

        public ResponseDto<BillDTO> GetBillById(int billId)
        {
            var bill = _billRepository.GetBillById(billId);
            if (bill == null)
            {
                return ResponseDto<BillDTO>.Fail("Bill not found!");
            }
            var billDto = _mapper.Map<BillDTO>(bill);
            return ResponseDto<BillDTO>.Success(billDto);
        }

        public ResponseDto<int> AddBill(BillAddDtoRequest bill)
        {
            var newBill = _mapper.Map<Bill>(bill);
            _billRepository.AddBill(newBill);
            return ResponseDto<int>.Success(newBill.BillId);
        }

        public void UpdateBill(BillUpdateDtoRequest bill)
        {
            var existingBill = _billRepository.GetBillById(bill.BillId);
            if (existingBill != null)
            {
                _mapper.Map(bill, existingBill);
                _billRepository.UpdateBill(existingBill);
            }
        }

        public void DeleteBill(int billId)
        {
            _billRepository.DeleteBill(billId);
        }
    }
}
