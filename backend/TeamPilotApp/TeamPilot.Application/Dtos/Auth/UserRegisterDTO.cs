namespace TeamPilot.Application.Dtos.Auth;

public class UserRegisterDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AvatarUrl { get; set; }
    public string Bio { get; set; }
}
