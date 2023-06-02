namespace TeamPilot.Application.Dtos.Tournament;

public class TournamentDTO
{
    public string TournamentId { get; set; }
    public string TournamentName { get; set; }
    public string TournamentFormat { get; set; }
    public decimal TournamentPrizePool { get; set; }
    public string TournamentLocation { get; set; }
    public string TournamentSponsor { get; set; }
    public DateTime TournamentStartDate { get; set; }
    public DateTime TournamentEndDate { get; set; }
    public List<MatchDTO> TournamentMatches { get; set; }
    public List<MatchDTO> FutureTournamentMatches { get; set; }
    public List<PastMatchDTO> PastTournamentMatches { get; set; }
    public List<TeamForTournamentDTO> TournamentParticipatingTeams { get; set; }
    public TeamForTournamentDTO? WinningTeam { get; set; }
    public MatchDTO UpcomingMatch { get; set; }
}