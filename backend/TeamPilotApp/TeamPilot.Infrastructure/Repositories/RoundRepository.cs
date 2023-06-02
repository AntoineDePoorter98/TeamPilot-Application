using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class RoundRepository : RepositoryBase<Round>, IRoundRepository
{
    public RoundRepository(TeamPilotDbContext context) : base(context)
    {
    }

    public async Task<List<IGrouping<Guid, Round>>> GetWonRoundsGroupedByTeamIdAsync()
    {
        return await _context.Rounds
            .GroupBy(x => x.TeamWinnerId)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Guid, Round>>> GetLostRoundsGroupedByTeamIdAsync()
    {
        return await _context.Rounds
            .GroupBy(x => x.Match!.Teams.First(y => y.TeamId != x.TeamWinnerId).TeamId)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Guid, Round>>> GetWonRoundsForTournamentIdGroupedByTeamIdAsync(Guid tournamentId)
    {
        return await _context.Rounds
            .Where(x => x.Match!.TournamentId == tournamentId)
            .GroupBy(x => x.TeamWinnerId)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Guid, Round>>> GetLostRoundsForTournamentIdGroupedByTeamIdAsync(Guid tournamentId)
    {
        return await _context.Rounds
            .Where(x => x.Match!.TournamentId == tournamentId)
            .GroupBy(x => x.Match!.Teams.First(y => y.TeamId != x.TeamWinnerId).TeamId)
            .ToListAsync();
    }
}
