namespace TeamPilot.Application.Dtos.Tournament;

public class MatchDTO
{
    public string MatchId { get; set; }
    public string MatchLengthInMinutes { get; set; }
    public string MatchDate { get; set; }
    public List<TeamForTournamentDTO> ParticipatingTeams { get; set; }
}