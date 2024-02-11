using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        void AddPayment(PaymentAddDtoRequest paymentDto);
        IEnumerable<PaymentDTO> GetAllPayments();
        IEnumerable<PaymentDTO> GetPaymentsByUserId(int userId);
        decimal GetTotalAmountPaidByUser(int userId);
    }
}
