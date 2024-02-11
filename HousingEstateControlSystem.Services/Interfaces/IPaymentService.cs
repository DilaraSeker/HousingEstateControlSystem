using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        void AddPayment(PaymentAddDtoRequest paymentDto);
        IEnumerable<PaymentDTO> GetAllPayments();
        IEnumerable<PaymentDTO> GetPaymentsByUserId(string userId);
        decimal GetTotalAmountPaidByUser(string userId);
    }
}
