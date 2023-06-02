using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
{
    public PlayerRepository(TeamPilotDbContext context) : base(context)
    {

    }

    public async Task<Player> GetPlayerTournamentsAndMatchesAsync(string playerId)
    {
        return await _context.Players.AsNoTrackingWithIdentityResolution()
            .Include(p => p.Team)
                .ThenInclude(t => t.Matches)
                    .ThenInclude(m => m.Tournament)
            .Include(p => p.Team)
                .ThenInclude(t => t.Matches)
                    .ThenInclude(m => m.Teams)
            .FirstOrDefaultAsync(p => p.UserId == Guid.Parse(playerId));
    }

}
