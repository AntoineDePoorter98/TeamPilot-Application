using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamPilot.Application.Dtos.Auth;
using TeamPilot.Application.Exceptions;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task Register(UserRegisterDTO userRegisterDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);

            var user = new RegisteredUser
            {
                Email = userRegisterDto.Email,
                PasswordHash = passwordHash,
                Nickname = userRegisterDto.Nickname,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Bio = userRegisterDto.Bio,
                AvatarUrl = userRegisterDto.AvatarUrl
            };

            await _userRepository.InsertAsync(user);
        }

        public async Task<UserLoginResponseDTO> Login(UserLoginDTO userLoginDTO)
        {
            var user = await Authenticate(userLoginDTO);
            var token = GenerateJwt(user);

            var response = new UserLoginResponseDTO
            {
                Token = token
            };

            return response;
        }

        private async Task<User> Authenticate(UserLoginDTO userDto)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Email == userDto.Email);

            if (user == null)
            {
                throw new UnknownIdentityException();
            }

            var isCorrectPassword = BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash);

            if (!isCorrectPassword)
            {
                throw new UnknownIdentityException();
            }

            return user;
        }

        public string GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("type", user.GetType().Name)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
