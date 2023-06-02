namespace TeamPilot.Application.Dtos.team
{
    public class TeamDTO
    {
        public string TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? TeamManagerId { get; set; }
        public List<PlayerDTO>? Players { get; set; }
    }
}
