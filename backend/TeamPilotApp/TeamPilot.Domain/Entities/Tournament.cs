namespace TeamPilot.Domain.Entities;

public class Tournament
{
    public Guid TournamentId { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string TournamentFormat { get; set; }
    public string MainSponsorName { get; set; }
    public decimal PrizeMoney { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid TournamentManagerId { get; set; }
    public Guid? WinningTeamId { get; set; }
    public TournamentManager TournamentManager { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
    public List<RegisteredUser> Followers { get; set; } = new List<RegisteredUser>();
    public List<Match> Matches { get; set; } = new List<Match>();
}
