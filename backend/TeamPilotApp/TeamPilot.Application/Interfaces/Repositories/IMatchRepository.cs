using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface IMatchRepository : IRepository<Match>
{
    Task<List<Match>> GetMatchAggregatesAsync();
    Task<List<IGrouping<Guid, Match>>> GetWonMatchesGroupedByTeamIdAsync();
    Task<List<IGrouping<Guid, Match>>> GetLostMatchesGroupedByTeamIdAsync();
    Task<List<IGrouping<Guid, Match>>> GetWonMatchesForTournamentIdGroupedByTeamIdAsync(Guid tournamentId);
    Task<List<IGrouping<Guid, Match>>> GetLostMatchesForTournamentIdGroupedByTeamIdAsync(Guid tournamentId);
}
