namespace HousingEstateControlSystem.DTOs.User
{
    public class UserAddDtoRequest
    {
        public string FullName { get; set; }
        public string TCNo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? CondoId { get; set; }
    }
}
