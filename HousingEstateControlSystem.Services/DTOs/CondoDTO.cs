
namespace HousingEstateControlSystem.Services.DTOs
{
    public class CondoDTO
    {
        public int CondoId { get; set; }
        public string Block { get; set; }
        public bool IsOccupied { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; }
        public bool IsTenant { get; set; }
    }
}
