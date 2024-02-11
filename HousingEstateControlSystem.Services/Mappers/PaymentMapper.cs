using AutoMapper;
using HousingEstateControlSystem.DTOs;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Services.Mappers
{
    public class PaymentMapper
    {
        private readonly IMapper _mapper;

        public PaymentMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PaymentDTO MapToPaymentDTO(Payment payment)
        {
            return _mapper.Map<PaymentDTO>(payment);
        }

        public Payment MapToPaymentEntity(PaymentAddDtoRequest paymentDto)
        {
            return _mapper.Map<Payment>(paymentDto);
        }
    }
}
