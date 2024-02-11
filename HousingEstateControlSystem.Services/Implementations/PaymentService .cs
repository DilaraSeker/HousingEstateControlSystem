using HousingEstateControlSystem.DTOs;
using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Services.Interfaces;
using HousingEstateControlSystem.Services.Mappers;


namespace HousingEstateControlSystem.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentMapper _paymentMapper;

        public PaymentService(IPaymentRepository paymentRepository, PaymentMapper paymentMapper)
        {
            _paymentRepository = paymentRepository;
            _paymentMapper = paymentMapper;
        }

        public void AddPayment(PaymentAddDtoRequest paymentDto)
        {
            var payment = _paymentMapper.MapToPaymentEntity(paymentDto);
            payment.PaymentDate = DateTime.Now; // Ödemenin yapıldığı tarihi ekler
            _paymentRepository.AddPayment(payment);
        }

        public IEnumerable<PaymentDTO> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            var paymentDTOs = new List<PaymentDTO>();
            foreach (var payment in payments)
            {
                paymentDTOs.Add(_paymentMapper.MapToPaymentDTO(payment));
            }
            return paymentDTOs;
        }

        public IEnumerable<PaymentDTO> GetPaymentsByUserId(string userId)
        {
            var payments = _paymentRepository.GetPaymentsByUserId(userId);
            var paymentDTOs = new List<PaymentDTO>();
            foreach (var payment in payments)
            {
                paymentDTOs.Add(_paymentMapper.MapToPaymentDTO(payment));
            }
            return paymentDTOs;
        }


        public decimal GetTotalAmountPaidByUser(string userId)
        {
            return _paymentRepository.GetTotalAmountPaidByUser(userId);
        }

    }
}
