using Microsoft.EntityFrameworkCore;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess;

namespace TeamPilot.Infrastructure.Repositories;

public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(TeamPilotDbContext context) : base(context)
    {
    }

    public async Task<List<Article>> GetAllArticlesForFollowingAsync(Guid userId)
    {
        List<Article> toReturn = new();
        RegisteredUser ru = await _context.RegisteredUsers.Include(x => x.FollowedPlayers).Include(x => x.FollowedTeams).Include(x => x.FollowedTournaments).FirstOrDefaultAsync(x => x.UserId == userId);

        // Getting the followedX id's
        List<Guid> followedPlayerIds = ru.FollowedPlayers.Select(o => o.UserId).ToList();
        List<Guid> followedTeamIds = ru.FollowedTeams.Select(o => o.TeamId).ToList();
        List<Guid> followedTournamentIds = ru.FollowedTournaments.Select(o => o.TournamentId).ToList();

        // Checking for all the followed player id's if there are articles about that player and if so adds them to output list, also for teams and tournaments
        foreach (var playerId in followedPlayerIds)
        {
            var pArticles = _context.Articles.Where(x => x.PlayerId == playerId).ToList();
            toReturn.AddRange(pArticles);
        }
        foreach (var teamId in followedTeamIds)
        {
            var teArticles = _context.Articles.Where(x => x.TeamId == teamId).ToList();
            toReturn.AddRange(teArticles);
        }
        foreach (var tournamentId in followedTournamentIds)
        {
            var toArticles = _context.Articles.Where(x => x.TournamentId == tournamentId).ToList();
            toReturn.AddRange(toArticles);
        }
        return toReturn.Distinct().ToList();
    }
}
