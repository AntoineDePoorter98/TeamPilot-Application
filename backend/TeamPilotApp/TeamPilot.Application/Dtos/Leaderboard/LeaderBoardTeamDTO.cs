namespace TeamPilot.Application.Dtos.Leaderboard
{
    public class LeaderBoardTeamDTO
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamAvatarUrl { get; set; }
        public int TeamWonMatches { get; set; }
        public int TeamLostMatches { get; set; }
        public int TeamWonRounds { get; set; }
        public int TeamLostRounds { get; set; }
    }
}
