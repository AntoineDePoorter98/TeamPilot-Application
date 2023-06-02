namespace TeamPilot.Application.Dtos.Leaderboard
{
    public class LeaderBoardPlayerDTO
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerAvatarUrl { get; set; }
        public int PlayerKills { get; set; }
        public int PlayerDeaths { get; set; }
        public double PlayerKDRatio => PlayerDeaths != 0 ? (double)PlayerKills / (double)PlayerDeaths : (double)PlayerKills;

    }
}
