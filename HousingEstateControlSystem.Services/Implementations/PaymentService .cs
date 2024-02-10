using AutoMapper;
using HousingEstateControlSystem.DTOs;
using HousingEstateControlSystem.Repositories.Models;
using HousingEstateControlSystem.Services.Interfaces;
using HousingEstateControlSystem.Repositories;

namespace HousingEstateControlSystem.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public PaymentDTO AddPayment(PaymentAddDTORequest paymentAddDTO)
        {
            var payment = _mapper.Map<Payment>(paymentAddDTO);
            payment.PaymentDate = DateTime.UtcNow;
            var addedPayment = _paymentRepository.AddPayment(payment);
            return _mapper.Map<PaymentDTO>(addedPayment);
        }

        public void DeletePayment(int paymentId)
        {
            _paymentRepository.DeletePayment(paymentId);
        }

        public List<PaymentDTO> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            return _mapper.Map<List<PaymentDTO>>(payments);
        }

        public PaymentDTO GetPaymentById(int paymentId)
        {
            var payment = _paymentRepository.GetPaymentById(paymentId);
            return _mapper.Map<PaymentDTO>(payment);
        }

        public void UpdatePayment(PaymentUpdateDTORequest paymentUpdateDTO)
        {
            var existingPayment = _paymentRepository.GetPaymentById(paymentUpdateDTO.PaymentId);
            if (existingPayment == null)
            {
                throw new ApplicationException("Payment not found");
            }

            _mapper.Map(paymentUpdateDTO, existingPayment);
            _paymentRepository.UpdatePayment(existingPayment);
        }
    }
}
