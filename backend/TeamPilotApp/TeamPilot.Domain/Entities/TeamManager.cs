namespace TeamPilot.Domain.Entities; 
public class TeamManager : User
{
    public List<Team> Teams { get; set; } = new List<Team>();
}
