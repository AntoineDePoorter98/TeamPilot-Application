using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.Leaderboard;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Controllers
{
    [ApiController]
    [Route("leaderboards")]
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;

        public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        // Global player ranking
        [HttpGet("players")]
        public async Task<List<LeaderBoardPlayerDTO>> GetPlayersLeaderBoard()
        {
            var players = await _leaderboardService.GetPlayersForLeaderboardAsync();
            return players;
        }

        // Global team ranking
        [HttpGet("teams")]
        public async Task<List<LeaderBoardTeamDTO>> GetTeamsLeaderBoard()
        {
            var teams = await _leaderboardService.GetTeamsForLeaderboardAsync();
            return teams;
        }

        // Player ranking in tournament
        [HttpGet("tournament/{tournamentId}/players")]
        public async Task<List<LeaderBoardPlayerDTO>> GetPlayersInTournamentLeaderBoard([FromRoute] string tournamentId)
        {
            var players = await _leaderboardService.GetPlayersForLeaderboardInTournamentAsync(tournamentId);
            return players;
        }

        // Team ranking in tournament
        [HttpGet("tournament/{tournamentId}/teams")]
        public async Task<List<LeaderBoardTeamDTO>> GetTeamsInTournamentLeaderBoard([FromRoute] string tournamentId)
        {
            var teams = await _leaderboardService.GetTeamsForLeaderboardInTournamentAsync(tournamentId);
            return teams;
        }
    }
}
