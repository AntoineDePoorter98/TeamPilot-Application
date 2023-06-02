using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class TournamentRepository : RepositoryBase<Tournament>, ITournamentRepository
{
    public TournamentRepository(TeamPilotDbContext context) : base(context)
    {
    }

    #region Basic 5 CRUD Methods and Extra Methods

    public async Task<List<Tournament>> GetAllTournamentsAsync()
    {
        return await _context.Tournaments.ToListAsync();
    }

    public async Task<Tournament> GetTournamentByIDAsync(Guid tournamentId)
    {
        return await _context.Tournaments
            .Include(x=>x.Matches)
                .ThenInclude(y=>y.Rounds)
                    .ThenInclude(z=>z.RoundEvents)
                        .ThenInclude(a=>a.KillingPlayer)
            .Include(x => x.Matches)
                .ThenInclude(y => y.Rounds)
                    .ThenInclude(z => z.RoundEvents)
                        .ThenInclude(a=>a.KilledPlayer)
            .Include(x => x.Matches)
                .ThenInclude(y => y.Teams)
            .Include(x=>x.Teams)
            .Where(x => x.TournamentId == tournamentId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Tournament>> GetTournamentsForTournamentManager(Guid tournamentManagerId)
    {
        return await _context.Tournaments.Where(x => x.TournamentManagerId == tournamentManagerId).ToListAsync();
    }

    public async Task CreateTournamentAsync(Tournament tournament)
    {
        await _context.Tournaments.AddAsync(tournament);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTournamentAsync(Tournament tournament)
    {
        _context.Tournaments.Update(tournament);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTournamentAsync(Guid tournamentId)
    {
        var tournament = await _context.Tournaments.FirstOrDefaultAsync(x=>x.TournamentId == tournamentId);
        if (tournament != null)
        {
            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddTeamsToTournamentRaw(string tournamentId, string teamId)
    {
        await _context.Database.ExecuteSqlRawAsync($"INSERT INTO dbo.tournaments_teams ([TeamId], [TournamentId]) VALUES ('{teamId}', '{tournamentId}')");
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTournamentTeamsRaw(string tournamentId, string teamId)
    {
        await _context.Database.ExecuteSqlRawAsync($"UPDATE dbo.tournaments_teams ([TeamId], [TournamentId]) VALUES ('{teamId}', '{tournamentId}')");
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeamsForTournamentRaw(string tournamentId)
    {
        await _context.Database.ExecuteSqlRawAsync($"DELETE FROM dbo.tournaments_teams WHERE TournamentId = '{tournamentId}'");
    }

    #endregion
}
