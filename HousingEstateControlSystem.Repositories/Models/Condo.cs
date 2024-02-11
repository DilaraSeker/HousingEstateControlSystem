
namespace HousingEstateControlSystem.Repositories.Models
{
    public class Condo
    {
        public int CondoId { get; set; }
        public string Block { get; set; }
        public bool IsOccupied { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int OwnerId { get; set; } // Foreign key for User
        public bool IsTenant { get; set; } // True if rented out by a tenant, false if owned by the owner
        public ICollection<User> Users { get; set; } 
        public ICollection<Dues> Dues { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
