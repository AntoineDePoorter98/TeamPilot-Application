namespace TeamPilot.Infrastructure.DataAccess.Seeding.Models
{
    public class TeamMatches
    {
        public Guid TeamId { get; set; }
        public Guid MatchId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TeamMatches item &&
                   TeamId.Equals(item.TeamId) &&
                   MatchId.Equals(item.MatchId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TeamId, MatchId);
        }
    }
}
