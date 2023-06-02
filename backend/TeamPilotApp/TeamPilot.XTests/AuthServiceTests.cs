using TeamPilot.Application.Dtos.Auth;
using TeamPilot.Application.Exceptions;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Application.Services;

namespace TeamPilot.Tests;

public class AuthServiceTests
{
    private readonly AuthService _authService;
    private readonly IUserRepository _userRepository;

    public AuthServiceTests(AuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    [Fact]
    public async Task Register()
    {
        //Arrange
        var userRegisterDTO = new UserRegisterDTO
        {
            Email = "test@test.com",
            Password = "PassWord123!",
            FirstName = "Test",
            LastName = "Test",
            Bio = "Test",
            AvatarUrl = "Test",
            Nickname = "Test"
        };

        //Act
        await _authService.Register(userRegisterDTO);

        //Assert
        var user = await _userRepository.FirstOrDefaultAsync(x => x.Email == userRegisterDTO.Email);
        Assert.Equal(userRegisterDTO.Email, user?.Email);
    }

    [Fact]
    public async Task Login()
    {
        //Arrange
        var userRegisterDTO = new UserRegisterDTO
        {
            Email = "test2@test.com",
            Password = "PassWord123!",
            FirstName = "Test",
            LastName = "Test",
            Bio = "Test",
            AvatarUrl = "Test",
            Nickname = "Test"
        };

        var userLoginDTO = new UserLoginDTO
        {
            Email = "test2@test.com",
            Password = "PassWord123!"
        };

        await _authService.Register(userRegisterDTO);

        //Act
        var response = await _authService.Login(userLoginDTO);

        //Assert
        Assert.NotNull(response.Token);
    }

    [Fact]
    public async Task WrongPasswordShouldThrow()
    {
        //Arrange
        var userRegisterDTO = new UserRegisterDTO
        {
            Email = "test3@test.com",
            Password = "PassWord123!",
            FirstName = "Test",
            LastName = "Test",
            Bio = "Test",
            AvatarUrl = "Test",
            Nickname = "Test"
        };

        var userLoginDTO = new UserLoginDTO
        {
            Email = "test3@test.com",
            Password = "Wrong password"
        };

        await _authService.Register(userRegisterDTO);

        //Act
        Task result() => _authService.Login(userLoginDTO);

        //Assert
        await Assert.ThrowsAsync<UnknownIdentityException>(result);
    }
}
