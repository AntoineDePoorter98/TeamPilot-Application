using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class MatchRepository : RepositoryBase<Match>, IMatchRepository
{
    public MatchRepository(TeamPilotDbContext context) : base(context)
    {

    }

    public async Task<List<Match>> GetMatchAggregatesAsync()
    {
        return await _context.Matches
            .Include(x => x.Teams)
            .Include(x => x.Rounds)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Guid, Match>>> GetWonMatchesGroupedByTeamIdAsync()
    {
        return await _context.Matches
            .GroupBy(x => x.WinningTeamId)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Guid, Match>>> GetLostMatchesGroupedByTeamIdAsync()
    {
        return await _context.Matches
            .GroupBy(x => x.Teams.First(y => y.TeamId != x.WinningTeamId).TeamId)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Guid, Match>>> GetWonMatchesForTournamentIdGroupedByTeamIdAsync(Guid tournamentId)
    {
        return await _context.Matches
            .Where(x => x.TournamentId == tournamentId)
            .GroupBy(x => x.WinningTeamId)
            .ToListAsync();
    }

    public async Task<List<IGrouping<Guid, Match>>> GetLostMatchesForTournamentIdGroupedByTeamIdAsync(Guid tournamentId)
    {
        return await _context.Matches
            .Where(x => x.TournamentId == tournamentId)
            .GroupBy(x => x.Teams.First(y => y.TeamId != x.WinningTeamId).TeamId)
            .ToListAsync();
    }
}
