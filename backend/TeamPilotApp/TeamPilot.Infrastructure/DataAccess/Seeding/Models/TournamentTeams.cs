namespace TeamPilot.Infrastructure.DataAccess.Seeding.Models
{
    public class TournamentTeams
    {
        public Guid TournamentId { get; set; }
        public Guid TeamId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TournamentTeams item &&
                   TournamentId.Equals(item.TournamentId) &&
                   TeamId.Equals(item.TeamId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TournamentId, TeamId);
        }
    }
}
