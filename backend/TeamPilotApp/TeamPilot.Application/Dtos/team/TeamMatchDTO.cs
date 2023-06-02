using TeamPilot.Application.Dtos.Tournament;

namespace TeamPilot.Application.Dtos.team
{
    public class TeamMatchDTO
    {
        public string MatchId { get; set; }
        public string TournamentId { get; set; }
        public string TournamentTitle { get; set; }
        public string MatchDate { get; set; }
        public List<TeamForTournamentDTO>? ParticipatingTeams { get; set; }
    }
}
