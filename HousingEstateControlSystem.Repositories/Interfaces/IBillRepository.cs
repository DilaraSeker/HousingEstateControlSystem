﻿using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Interfaces
{
    public interface IBillRepository
    {
        Bill GetBillById(int billId);
        List<Bill> GetAllBills();
        Bill AddBill(Bill bill);
        void UpdateBill(Bill bill);
        void DeleteBill(int billId);
    }
}
