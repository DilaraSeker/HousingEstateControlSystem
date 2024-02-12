using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using HousingEstateControlSystem.DTOs.Auth;
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
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration configuration, IUserRepository userRepository, IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _secret = configuration["JwtSettings:Secret"];
            _issuer = configuration["JwtSettings:Issuer"];
            _audience = configuration["JwtSettings:Audience"];
            _expirationInMinutes = int.Parse(configuration["JwtSettings:ExpirationInMinutes"]);

            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public AuthResponseDTO Register(RegisterDTO registerDto)
        {
            if (_userRepository.GetUserByEmail(registerDto.Email) != null)
                return new AuthResponseDTO { Success = false, Message = "Email already registered" };

            var user = _mapper.Map<User>(registerDto);
            _userRepository.AddUser(user);

            // Rol atama 
            _userRoleRepository.AddUserRole(new UserRole { UserId = user.Id });

            var response = _mapper.Map<AuthResponseDTO>(user);
            response.Token = GenerateJwtToken(user);
            response.Success = true; // Başarılı işlem olduğunu belirtmek için success alanı ayarlandı
            return response;
        }


        public AuthResponseDTO Login(LoginDTO loginDto)
        {
            var user = _userRepository.GetUserByEmail(loginDto.Email);
            if (user == null)
                return new AuthResponseDTO { Success = false, Message = "User not found" };

            if (!VerifyPasswordHash(loginDto.Password, user.PasswordHash))
                return new AuthResponseDTO { Success = false, Message = "Invalid email or password" };

            var response = _mapper.Map<AuthResponseDTO>(user);
            response.Token = GenerateJwtToken(user);
            response.Success = true; // Başarılı işlem olduğunu belirtmek için success alanı ayarlandı
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

        private bool VerifyPasswordHash(string password, string passwordHashString)
        {
            if (passwordHashString == null)
            {
                return false; // veya isteğe bağlı olarak istisna fırlatabilirsiniz
            }

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
