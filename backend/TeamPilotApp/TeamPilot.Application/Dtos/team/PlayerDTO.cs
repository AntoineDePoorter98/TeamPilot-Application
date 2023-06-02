namespace TeamPilot.Application.Dtos.team
{
    public class PlayerDTO
    {
        public string UserId { get; set; }
        public string? UserType { get; set; }
        public string? Nickname { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }
        public string? TeamId { get; set; }
        public string? MonthlySalary { get; set; }
    }
}
