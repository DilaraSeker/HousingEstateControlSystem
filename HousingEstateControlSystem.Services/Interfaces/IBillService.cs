using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IBillService
    {
        ResponseDto<List<BillDTO>> GetAllBills();
        ResponseDto<BillDTO> GetBillById(int billId);
        ResponseDto<int> AddBill(BillAddDtoRequest bill);
        void UpdateBill(BillUpdateDtoRequest bill);
        void DeleteBill(int billId);
    }
}
