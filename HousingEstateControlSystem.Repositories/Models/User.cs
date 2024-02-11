
namespace HousingEstateControlSystem.Repositories.Models
{
    public class User
    {
        public int UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string TCNo { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        // Condo property to User class
        public int? CondoId { get; set; } // Can be Nullable 
        public Condo Condo { get; set; } // User may have a Condo
        public ICollection<Payment> Payments { get; set; }
    }
}
