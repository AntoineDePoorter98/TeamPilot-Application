namespace TeamPilot.Infrastructure.DataAccess.Seeding.Models
{
    public class RegisteredUsersFollowedTournament
    {
        public Guid TournamentId { get; set; }
        public Guid RegisteredUserId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is RegisteredUsersFollowedTournament item &&
                   TournamentId.Equals(item.TournamentId) &&
                   RegisteredUserId.Equals(item.RegisteredUserId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TournamentId, RegisteredUserId);
        }
    }
}
