using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface IRoundRepository : IRepository<Round>
{
    Task<List<IGrouping<Guid, Round>>> GetWonRoundsGroupedByTeamIdAsync();
    Task<List<IGrouping<Guid, Round>>> GetLostRoundsGroupedByTeamIdAsync();
    Task<List<IGrouping<Guid, Round>>> GetWonRoundsForTournamentIdGroupedByTeamIdAsync(Guid tournamentId);
    Task<List<IGrouping<Guid, Round>>> GetLostRoundsForTournamentIdGroupedByTeamIdAsync(Guid tournamentId);
}
