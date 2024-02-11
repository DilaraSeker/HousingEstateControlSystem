using HousingEstateControlSystem.Repositories.Models;


namespace HousingEstateControlSystem.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        IEnumerable<Payment> GetAllPayments();
        IEnumerable<Payment> GetPaymentsByUserId(string userId);
        IEnumerable<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Payment> GetPaymentsByType(PaymentType paymentType);
        decimal GetTotalAmountPaidByUser(string userId);
  
    }
}
