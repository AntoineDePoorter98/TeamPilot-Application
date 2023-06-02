using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface ITournamentManagerRepository : IRepository<TournamentManager>
{
    Task<TournamentManager> GetTournamentManagerTournamentsAndMatchesAsync(string tournamentManagerId);
}
