namespace TeamPilot.Infrastructure.DataAccess.Seeding.Models
{
    public class RegisteredUsersFollowedTeams
    {
        public Guid TeamId { get; set; }
        public Guid RegisteredUserId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is RegisteredUsersFollowedTeams item &&
                   TeamId.Equals(item.TeamId) &&
                   RegisteredUserId.Equals(item.RegisteredUserId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TeamId, RegisteredUserId);
        }
    }
}
