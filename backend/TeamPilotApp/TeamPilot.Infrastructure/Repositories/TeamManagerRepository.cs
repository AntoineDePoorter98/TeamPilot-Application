using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class TeamManagerRepository : RepositoryBase<TeamManager>, ITeamManagerRepository
{
    public TeamManagerRepository(TeamPilotDbContext context) : base(context)
    {

    }

    public async Task<TeamManager> GetTeamManagerTournamentsAndMatchesAsync(string teamManagerId)
    {
        return await _context.TeamManagers.AsNoTrackingWithIdentityResolution()
            .Include(tm => tm.Teams)
                .ThenInclude(t => t.Matches)
                    .ThenInclude(m => m.Tournament)
            .Include(tm => tm.Teams)
                .ThenInclude(t => t.Matches)
                    .ThenInclude(m => m.Teams)
            .FirstOrDefaultAsync(tm => tm.UserId == Guid.Parse(teamManagerId));
    }
}
