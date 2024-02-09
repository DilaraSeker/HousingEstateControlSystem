namespace HousingEstateControlSystem.DTOs.User
{
    public class UserUpdateDtoRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string TCNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
