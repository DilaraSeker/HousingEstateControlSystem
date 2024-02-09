namespace HousingEstateControlSystem.DTOs.Dues
{
    public class DuesDTO
    {
        public int DuesId { get; set; }
        public int CondoId { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
