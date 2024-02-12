using Microsoft.AspNetCore.Identity;

namespace HousingEstateControlSystem.Repositories.Models
{
    public class UserRole : IdentityUserRole<string>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; } 
    }
}
