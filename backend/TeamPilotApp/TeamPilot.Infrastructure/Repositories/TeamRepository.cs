using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class TeamRepository : RepositoryBase<Team>, ITeamRepository
{
    public TeamRepository(TeamPilotDbContext context) : base(context){}

    public async Task<Team?> FirstOrDefaultIncludingPlayersAsync(Expression<Func<Team, bool>> predicate) { return await _context.Teams.Include(x=>x.Players).AsNoTracking().FirstOrDefaultAsync(predicate); }
    public async Task<List<Team>> GetAllTeamsIncludingPlayers() { return await _context.Teams.Include(x=>x.Players).ToListAsync(); }
    public async Task<List<Tournament>> GetAllTournamentsIncludingMatchesAndTeamMatches() { return await _context.Tournaments.Include(x=>x.Matches).ThenInclude(x=>x.Teams).ToListAsync();}
}
