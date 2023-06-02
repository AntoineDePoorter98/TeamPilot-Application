using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class RoundEventRepository : RepositoryBase<RoundEvent>, IRoundEventRepository
{
    public RoundEventRepository(TeamPilotDbContext context) : base(context)
    {

    }

    public async Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsGroupedByKillingPlayerAsync()
    {
        return await _context.RoundEvents
            .GroupBy(x => x.KillingPlayer)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsGroupedByKilledPlayerAsync()
    {
        return await _context.RoundEvents
            .GroupBy(x => x.KilledPlayer)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsForTournamentIdGroupedByKillingPlayerAsync(Guid tournamentId)
    {
        return await _context.RoundEvents
            .Where(x => x.Round.Match!.TournamentId == tournamentId)
            .GroupBy(x => x.KillingPlayer)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsForTournamentIdGroupedByKilledPlayerAsync(Guid tournamentId)
    {
        return await _context.RoundEvents
            .Where(x => x.Round.Match!.TournamentId == tournamentId)
            .GroupBy(x => x.KilledPlayer)
            .ToListAsync();
    }
}
