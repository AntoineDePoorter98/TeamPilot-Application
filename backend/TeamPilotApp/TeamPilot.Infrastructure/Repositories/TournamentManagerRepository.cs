using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class TournamentManagerRepository : RepositoryBase<TournamentManager>, ITournamentManagerRepository
{
    public TournamentManagerRepository(TeamPilotDbContext context) : base(context)
    {

    }

    public async Task<TournamentManager> GetTournamentManagerTournamentsAndMatchesAsync(string tournamentManagerId)
    {
        return await _context.TournamentManagers.AsNoTrackingWithIdentityResolution()
            .Include(tm => tm.Tournaments)
                .ThenInclude(t => t.Matches)
                    .ThenInclude(m => m.Teams)
            .FirstOrDefaultAsync(tm => tm.UserId == Guid.Parse(tournamentManagerId));
    }
}
