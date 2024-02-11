
namespace HousingEstateControlSystem.DTOs
{
    public class PaymentUpdateRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DuesId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType Type { get; set; }
    }
}
