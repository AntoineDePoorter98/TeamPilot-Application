namespace TeamPilot.Application.Dtos.Tournament;

public class NewTournamentDTO
{
    public string? TournamentId { get; set; }
    public string TournamentName { get; set; }
    public string TournamentFormat { get; set; }
    public decimal TournamentPrizePool { get; set; }
    public string TournamentLocation { get; set; }
    public string TournamentSponsor { get; set; }
    public string TournamentStartDate { get; set; }
    public string TournamentEndDate { get; set; }
    public List<TeamForTournamentDTO> TournamentParticipatingTeams { get; set; }
}