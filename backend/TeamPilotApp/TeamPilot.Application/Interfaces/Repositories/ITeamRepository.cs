using System.Linq.Expressions;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface ITeamRepository : IRepository<Team>
{
    Task<Team?> FirstOrDefaultIncludingPlayersAsync(Expression<Func<Team, bool>> predicate);
    Task<List<Team>> GetAllTeamsIncludingPlayers();
    Task<List<Tournament>> GetAllTournamentsIncludingMatchesAndTeamMatches();
}

