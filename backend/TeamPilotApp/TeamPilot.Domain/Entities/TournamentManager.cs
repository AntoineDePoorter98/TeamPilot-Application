namespace TeamPilot.Domain.Entities;

public class TournamentManager : User
{
    public List<Tournament> Tournaments { get; set; } = new List<Tournament>();
}
