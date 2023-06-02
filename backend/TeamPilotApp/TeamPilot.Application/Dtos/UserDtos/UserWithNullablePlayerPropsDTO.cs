namespace TeamPilot.Application.Dtos.UserDtos
{
    public class UserWithNullablePlayerPropsDTO
    {
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public string Bio { get; set; }
        public decimal? MonthlySalary { get; set; }
        public string? TeamId { get; set; }
    }
}
