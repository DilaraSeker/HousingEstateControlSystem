
namespace HousingEstateControlSystem.DTOs.Bill
{
    public class BillAddDtoRequest
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int CondoId { get; set; }
    }
}
