using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface IRegisteredUserRepository : IRepository<RegisteredUser>
{
    Task AddFollowFromItemToRegisteredUser(string userId, string itemId, string itemType);
    Task DeleteFollowFromItemToRegisteredUser(string userId, string itemId, string itemType);
    Task DeleteAllFollowsForRegisteredUser(string userId);
    Task<List<Player>> GetFollowedPlayersAsync(string userId);
}
