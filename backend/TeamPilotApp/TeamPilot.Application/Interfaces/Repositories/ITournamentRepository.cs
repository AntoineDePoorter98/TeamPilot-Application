using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface ITournamentRepository : IRepository<Tournament>
{
    Task<List<Tournament>> GetAllTournamentsAsync();
    Task<Tournament> GetTournamentByIDAsync(Guid tournamentId);
    Task<List<Tournament>> GetTournamentsForTournamentManager(Guid tournamentManagerId);
    Task CreateTournamentAsync(Tournament tournament);
    Task UpdateTournamentAsync(Tournament tournament);
    Task DeleteTournamentAsync(Guid tournamentId);
    Task AddTeamsToTournamentRaw(string tournamentId, string teamId);
    Task DeleteTeamsForTournamentRaw(string tournamentId);
}
