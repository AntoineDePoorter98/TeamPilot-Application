using System.Linq.Expressions;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface IPlayerRepository : IRepository<Player>
{
    Task<Player> GetPlayerTournamentsAndMatchesAsync(string playerId);
}
