using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HousingEstateControlSystem.Common;
using HousingEstateControlSystem.DTOs.Auth;
using HousingEstateControlSystem.Repositories;
using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;
using HousingEstateControlSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HousingEstateControlSystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expirationInMinutes;

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration configuration, IUserRepository userRepository, IMapper mapper)
        {
            _secret = configuration["JwtSettings:Secret"];
            _issuer = configuration["JwtSettings:Issuer"];
            _audience = configuration["JwtSettings:Audience"];
            _expirationInMinutes = int.Parse(configuration["JwtSettings:ExpirationInMinutes"]);

            _userRepository = userRepository;
            _mapper = mapper;
        }

        public AuthResponseDTO Register(RegisterDTO registerDto)
        {
            var existingUser = _userRepository.GetUserByEmail(registerDto.Email);
            if (existingUser != null)
                throw new Exception("Email already registered");

            var user = _mapper.Map<User>(registerDto);
            _userRepository.AddUser(user);

            var response = _mapper.Map<AuthResponseDTO>(user);
            response.Token = GenerateJwtToken(user);
            return response;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expirationInMinutes),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AuthResponseDTO Login(LoginDTO loginDto)
        {
            var user = _userRepository.GetUserByEmail(loginDto.Email);
            if (user == null || !VerifyPasswordHash(loginDto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            var response = _mapper.Map<AuthResponseDTO>(user);
            response.Token = GenerateJwtToken(user);
            return response;
        }

        private bool VerifyPasswordHash(string password, string passwordHashString)
        {
            byte[] passwordHash = Convert.FromBase64String(passwordHashString); // Convert string to byte array
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }



    }
}
