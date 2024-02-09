using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs;
using System;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IBillService
    {
        ResponseDto<List<BillDTO>> GetBills();
        ResponseDto<BillDTO> GetBill(int billId);
        ResponseDto<BillDTO> CreateBill(BillDTO billDto);
        ResponseDto<BillDTO> UpdateBill(int billId, BillDTO billDto);
        ResponseDto<bool> DeleteBill(int billId);
    }
}
