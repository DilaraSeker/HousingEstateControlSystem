
namespace HousingEstateControlSystem.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DuesId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType Type { get; set; }
    }
       public enum PaymentType
    {
        Dues,
        Bill
    }
}
