using HousingEstateControlSystem.DTOs;

namespace HousingEstateControlSystem.Services.Interfaces
{
    public interface IPaymentService
    {
        PaymentDTO GetPaymentById(int paymentId);
        List<PaymentDTO> GetAllPayments();
        PaymentDTO AddPayment(PaymentAddDTORequest paymentAddDTO);
        void UpdatePayment(PaymentUpdateDTORequest paymentUpdateDTO);
        void DeletePayment(int paymentId);
    }
}
