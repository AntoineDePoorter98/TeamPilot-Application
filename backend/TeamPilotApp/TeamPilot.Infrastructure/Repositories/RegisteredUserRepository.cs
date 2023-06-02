using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class RegisteredUserRepository : RepositoryBase<RegisteredUser>, IRegisteredUserRepository
{
    public RegisteredUserRepository(TeamPilotDbContext context) : base(context)
    {

    }
    public async Task AddFollowFromItemToRegisteredUser(string userId, string itemId, string itemType)
    {
        var user = await  _context.RegisteredUsers.AsTracking().FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        if (itemType == "Team")
        {
            var team = await _context.Set<Team>().AsTracking().FirstOrDefaultAsync(t => t.TeamId.ToString() == itemId);
            if (team == null)
            {
                throw new InvalidOperationException("Team not found.");
            }
            if (user.FollowedTeams.Any(t => t.TeamId.ToString() == itemId))
            {
                throw new InvalidOperationException("User is already following this team.");
            }
            user.FollowedTeams.Add(team);
        }
        else if (itemType == "Player")
        {
            var player = await _context.Set<Player>().AsTracking().FirstOrDefaultAsync(p => p.UserId.ToString() == itemId);
            if (player == null)
            {
                throw new InvalidOperationException("Player not found.");
            }
            if (user.FollowedPlayers.Any(p => p.UserId.ToString() == itemId))
            {
                throw new InvalidOperationException("User is already following this player.");
            }
            user.FollowedPlayers.Add(player);
        }
        else if (itemType == "Tournament")
        {
            var tournament = await _context.Set<Tournament>().AsTracking().FirstOrDefaultAsync(t => t.TournamentId.ToString() == itemId);
            if (tournament == null)
            {
                throw new InvalidOperationException("Tournament not found.");
            }
            if (user.FollowedTournaments.Any(t => t.TournamentId.ToString() == itemId))
            {
                throw new InvalidOperationException("User is already following this tournament.");
            }
            user.FollowedTournaments.Add(tournament);
        }
        else
        {
            throw new InvalidOperationException("Invalid item type.");
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteFollowFromItemToRegisteredUser(string userId, string itemId, string itemType)
    {
        var user = await _context.RegisteredUsers.AsTracking()
            .Include(u => u.FollowedTeams)
            .Include(u => u.FollowedPlayers)
            .Include(u => u.FollowedTournaments)
            .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        if (itemType == "Team")
        {
            var team = await _context.Set<Team>().AsTracking().FirstOrDefaultAsync(t => t.TeamId.ToString() == itemId);
            if (team == null)
            {
                throw new InvalidOperationException("Team not found.");
            }
            if (user.FollowedTeams.Any(t => t.TeamId.ToString() == itemId))
            {
                user.FollowedTeams.Remove(team);
            }
            else
            {
                throw new InvalidOperationException("User is not following this team.");
            }
        }
        else if (itemType == "Player")
        {
            var player = await _context.Set<Player>().AsTracking().FirstOrDefaultAsync(p => p.UserId.ToString() == itemId);
            if (player == null)
            {
                throw new InvalidOperationException("Player not found.");
            }
            if (user.FollowedPlayers.Any(p => p.UserId.ToString() == itemId))
            {
                user.FollowedPlayers.Remove(player);
            }
            else
            {
                throw new InvalidOperationException("User is not following this player.");
            }
        }
        else if (itemType == "Tournament")
        {
            var tournament = await _context.Set<Tournament>().AsTracking().FirstOrDefaultAsync(t => t.TournamentId.ToString() == itemId);
            if (tournament == null)
            {
                throw new InvalidOperationException("Tournament not found.");
            }
            if (user.FollowedTournaments.Any(t => t.TournamentId.ToString() == itemId))
            {
                user.FollowedTournaments.Remove(tournament);
            }
            else
            {
                throw new InvalidOperationException("User is not following this tournament.");
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid item type.");
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllFollowsForRegisteredUser(string userId)
    {
        var user = await _context.RegisteredUsers.AsTracking()
            .Include(u => u.FollowedTeams)
            .Include(u => u.FollowedPlayers)
            .Include(u => u.FollowedTournaments)
            .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        user.FollowedTeams.Clear();
        user.FollowedPlayers.Clear();
        user.FollowedTournaments.Clear();

        await _context.SaveChangesAsync();
    }

    public async Task<List<Player>> GetFollowedPlayersAsync(string userId)
    {
        var user = await _context.RegisteredUsers.AsTracking()
            .Include(u => u.FollowedPlayers)
            .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        return user.FollowedPlayers;
    }



}
