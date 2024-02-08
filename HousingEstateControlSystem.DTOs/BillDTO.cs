
namespace HousingEstateControlSystem.DTOs
{
    public class BillDTO
    {
        public int BillId { get; set; }
        public int CondoId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
