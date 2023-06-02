using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface IRoundEventRepository : IRepository<RoundEvent>
{
    Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsGroupedByKillingPlayerAsync();
    Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsGroupedByKilledPlayerAsync();
    Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsForTournamentIdGroupedByKillingPlayerAsync(Guid tournamentId);
    Task<List<IGrouping<Player, RoundEvent>>> GetRoundEventsForTournamentIdGroupedByKilledPlayerAsync(Guid tournamentId);
}
