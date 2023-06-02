namespace TeamPilot.Infrastructure.DataAccess.Seeding.Models
{
    public class RegisteredUsersFollowedPlayers
    {
        public Guid PlayerId { get; set; }
        public Guid RegisteredUserId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is RegisteredUsersFollowedPlayers item &&
                   PlayerId.Equals(item.PlayerId) &&
                   RegisteredUserId.Equals(item.RegisteredUserId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PlayerId, RegisteredUserId);
        }
    }
}
