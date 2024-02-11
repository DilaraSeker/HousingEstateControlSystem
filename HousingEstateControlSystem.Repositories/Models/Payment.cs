
namespace HousingEstateControlSystem.Repositories.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int CondoId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; } // Kredi Kartı / Nakit
        public string PaymentCategory { get; set; } // Aidat / Fatura
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
