using TeamPilot.Application.Dtos.Leaderboard;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Services;

public class LeaderboardService
{
    private readonly IRoundEventRepository _roundEventRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMatchRepository _matchRepository;
    private readonly IRoundRepository _roundRepository;

    public LeaderboardService(
        IRoundEventRepository roundEventRepository,
        IPlayerRepository playerRepository,
        ITeamRepository teamRepository,
        IMatchRepository matchRepository,
        IRoundRepository roundRepository
    )
    {
        _roundEventRepository = roundEventRepository;
        _playerRepository = playerRepository;
        _teamRepository = teamRepository;
        _matchRepository = matchRepository;
        _roundRepository = roundRepository;
    }

    public async Task<List<LeaderBoardPlayerDTO>> GetPlayersForLeaderboardAsync()
    {
        var players = await GetLeaderBoardPlayerListAsync();
        return players;
    }

    public async Task<List<LeaderBoardPlayerDTO>> GetPlayersForLeaderboardInTournamentAsync(string tournamentId)
    {
        var players = await GetLeaderBoardPlayerListAsync(tournamentId);
        return players;
    }

    public async Task<List<LeaderBoardTeamDTO>> GetTeamsForLeaderboardAsync()
    {
        var teams = await GetLeaderBoardTeamsListAsync();
        return teams;
    }

    public async Task<List<LeaderBoardTeamDTO>> GetTeamsForLeaderboardInTournamentAsync(string tournamentId)
    {
        var teams = await GetLeaderBoardTeamsListAsync(tournamentId);
        return teams;
    }

    private async Task<List<LeaderBoardPlayerDTO>> GetLeaderBoardPlayerListAsync(string? tournamentId = null)
    {
        var playersToReturn = new List<LeaderBoardPlayerDTO>();
        var players = new List<Player>();
        var playersGroupedByPlayerKills = new List<IGrouping<Player, RoundEvent>>();
        var playersGroupedByPlayerDeaths = new List<IGrouping<Player, RoundEvent>>();

        if (tournamentId == null)
        {
            players = await _playerRepository.GetAllAsync();
            playersGroupedByPlayerKills = await _roundEventRepository.GetRoundEventsGroupedByKillingPlayerAsync();
            playersGroupedByPlayerDeaths = await _roundEventRepository.GetRoundEventsGroupedByKilledPlayerAsync();
        }
        else
        {
            // SQL QUERY
            //SELECT*
            //FROM dbo.tournaments_teams
            //JOIN dbo.teams on dbo.tournaments_teams.TeamId = dbo.teams.TeamId
            //JOIN dbo.users on dbo.teams.TeamId = dbo.users.TeamId
            //WHERE TournamentId = '5c262b01-ee23-4f03-a92c-5d38c40801fd'
            players = await _playerRepository.FindManyAsync(x => x.Team!.Tournaments.Any(x => x.TournamentId == new Guid(tournamentId)));
            playersGroupedByPlayerKills = await _roundEventRepository.GetRoundEventsForTournamentIdGroupedByKillingPlayerAsync(new Guid(tournamentId));
            playersGroupedByPlayerDeaths = await _roundEventRepository.GetRoundEventsForTournamentIdGroupedByKilledPlayerAsync(new Guid(tournamentId));
        }

        foreach (var player in players)
        {
            var playerGroupedByPlayerKills = playersGroupedByPlayerKills.Find(x => x.Key.UserId == player.UserId)?.ToList();
            var playerGroupedByPlayerDeaths = playersGroupedByPlayerDeaths.Find(x => x.Key.UserId == player.UserId)?.ToList();

            playersToReturn.Add(new LeaderBoardPlayerDTO
            {
                PlayerId = player.UserId.ToString(),
                PlayerName = player.Nickname,
                PlayerAvatarUrl = player.AvatarUrl,
                PlayerKills = playerGroupedByPlayerKills?.Count ?? 0,
                PlayerDeaths = playerGroupedByPlayerDeaths?.Count ?? 0
            });
        }

        return playersToReturn.OrderByDescending(x => x.PlayerKDRatio).ToList();
    }

    private async Task<List<LeaderBoardTeamDTO>> GetLeaderBoardTeamsListAsync(string? tournamentId = null)
    {
        var teamToReturn = new List<LeaderBoardTeamDTO>();
        var teams = new List<Team>();
        var teamsGroupedByWonMatches = new List<IGrouping<Guid, Match>>();
        var teamsGroupedByLostMatches = new List<IGrouping<Guid, Match>>();
        var teamsGroupedByWonRounds = new List<IGrouping<Guid, Round>>();
        var teamsGroupedByLostRounds = new List<IGrouping<Guid, Round>>();

        if (tournamentId == null)
        {
            teams = await _teamRepository.GetAllAsync();
            teamsGroupedByWonMatches = await _matchRepository.GetWonMatchesGroupedByTeamIdAsync();
            teamsGroupedByLostMatches = await _matchRepository.GetLostMatchesGroupedByTeamIdAsync();
            teamsGroupedByWonRounds = await _roundRepository.GetWonRoundsGroupedByTeamIdAsync();
            teamsGroupedByLostRounds = await _roundRepository.GetLostRoundsGroupedByTeamIdAsync();
        }
        else
        {
            teams = await _teamRepository.FindManyAsync(x => x.Tournaments.Any(x => x.TournamentId == new Guid(tournamentId)));
            teamsGroupedByWonMatches = await _matchRepository.GetWonMatchesForTournamentIdGroupedByTeamIdAsync(new Guid(tournamentId));
            teamsGroupedByLostMatches = await _matchRepository.GetLostMatchesForTournamentIdGroupedByTeamIdAsync(new Guid(tournamentId));
            teamsGroupedByWonRounds = await _roundRepository.GetWonRoundsForTournamentIdGroupedByTeamIdAsync(new Guid(tournamentId));
            teamsGroupedByLostRounds = await _roundRepository.GetLostRoundsForTournamentIdGroupedByTeamIdAsync(new Guid(tournamentId));
        }

        foreach (var team in teams)
        {
            var teamWonMatches = teamsGroupedByWonMatches.Find(x => x.Key == team.TeamId)?.ToList();
            var teamLostMatches = teamsGroupedByLostMatches.Find(x => x.Key == team.TeamId)?.ToList();
            var teamWonRounds = teamsGroupedByWonRounds.Find(x => x.Key == team.TeamId)?.ToList();
            var teamLostRounds = teamsGroupedByLostRounds.Find(x => x.Key == team.TeamId)?.ToList();

            teamToReturn.Add(new LeaderBoardTeamDTO
            {
                TeamId = team.TeamId.ToString(),
                TeamName = team.TeamName,
                TeamAvatarUrl = team.AvatarUrl,
                TeamWonMatches = teamWonMatches?.Count ?? 0,
                TeamLostMatches = teamLostMatches?.Count ?? 0,
                TeamWonRounds = teamWonRounds?.Count ?? 0,
                TeamLostRounds = teamLostRounds?.Count ?? 0
            });
        }

        return teamToReturn;
    }


}
