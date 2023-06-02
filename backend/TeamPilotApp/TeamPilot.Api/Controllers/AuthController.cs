using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.Auth;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task Register([FromBody] UserRegisterDTO userRegisterDto)
        {
            await _authService.Register(userRegisterDto);
        }

        [HttpPost("login")]
        public async Task<UserLoginResponseDTO> Login([FromBody] UserLoginDTO userLoginDto)
        {
            var token = await _authService.Login(userLoginDto);
            return token;
        }
    }
}
