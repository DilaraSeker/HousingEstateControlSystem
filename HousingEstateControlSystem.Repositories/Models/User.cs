using System;

namespace HousingEstateControlSystem.Repositories.Models
{
    public class User
    {
        public int UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string TCNo { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
