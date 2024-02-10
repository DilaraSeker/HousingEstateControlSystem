
namespace HousingEstateControlSystem.DTOs
{
    public class PaymentUpdateDTORequest
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int CondoId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; } // Aidat/Fatura(Elektrik-Su-Doğalgaz)
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
