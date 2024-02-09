
namespace HousingEstateControlSystem.DTOs.Dues
{
    public class DuesAddDtoRequest
    {
        public int CondoId { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
