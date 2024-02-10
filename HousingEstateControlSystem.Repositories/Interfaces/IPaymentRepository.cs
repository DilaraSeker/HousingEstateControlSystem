﻿using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.DataAccess.Repositories
{
    public interface IPaymentRepository
    {
        Payment GetPaymentById(int paymentId);
        List<Payment> GetAllPayments();
        Payment AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int paymentId);
    }
}
