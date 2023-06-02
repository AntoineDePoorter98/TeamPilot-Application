namespace TeamPilot.Domain.Entities;

public abstract class User
{
    public Guid UserId { get; set; }
    public string Nickname { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
    public string Bio { get; set; }
    public string? PasswordHash { get; set; }
}
