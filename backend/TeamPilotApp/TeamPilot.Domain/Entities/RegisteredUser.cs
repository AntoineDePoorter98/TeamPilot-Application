namespace TeamPilot.Domain.Entities;

public class RegisteredUser : User
{
    public List<Team> FollowedTeams { get; set; } = new List<Team>();
    public List<Player> FollowedPlayers { get; set; } = new List<Player>();
    public List<Tournament> FollowedTournaments { get; set; } = new List<Tournament>();
}
