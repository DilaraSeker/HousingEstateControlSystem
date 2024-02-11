
namespace HousingEstateControlSystem.DTOs
{
    public class PaymentAddDtoRequest
    {
        public int UserId { get; set; }
        public int DuesId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType Type { get; set; }
    }
}
