namespace TeamPilot.Domain.Entities;

public class Match
{
    public Guid MatchId { get; set; }
    public double TimeSpanInMinutes { get; set; }
    public Guid TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public DateTime Date { get; set; }
    public Guid WinningTeamId { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
    public List<Round> Rounds { get; set; } = new List<Round>();
}

