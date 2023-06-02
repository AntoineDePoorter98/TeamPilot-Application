namespace TeamPilot.Domain.Entities;

public class Team
{
    public Guid TeamId { get; set; }
    public string TeamName { get; set; }
    public string AvatarUrl { get; set; }
    public Guid TeamManagerId { get; set; }
    public TeamManager TeamManager { get; set; }
    public List<Match> Matches { get; set; } = new List<Match>();
    public List<Round> Rounds { get; set; } = new List<Round>();
    public List<Player> Players { get; set; } = new List<Player>();
    public List<Tournament> Tournaments { get; set; } = new List<Tournament>();
    public List<RegisteredUser> Followers { get; set; } = new List<RegisteredUser>();
}
