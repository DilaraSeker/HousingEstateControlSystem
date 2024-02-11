
namespace HousingEstateControlSystem.Repositories.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int CondoId { get; set; } // Foreign key for Condo
        public Condo Condo { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime MonthYear { get; set; }
        public bool IsPaid { get; set; }
    }
}
