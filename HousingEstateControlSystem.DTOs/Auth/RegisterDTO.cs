﻿namespace HousingEstateControlSystem.DTOs.Auth
{
    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string TCNo { get; set; } 
        public string PhoneNumber { get; set; } 
    }
}