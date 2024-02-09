
namespace HousingEstateControlSystem.DTOs.Dues
{
    public class DuesUpdateDtoRequest
    {
        public int DuesId { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
