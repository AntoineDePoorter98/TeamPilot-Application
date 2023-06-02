using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.team;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Controllers
{
    [ApiController]
    [Route("teams")]
    public class TeamController: ControllerBase
    {
        private TeamService _teamService;

        public TeamController(TeamService teamService) { _teamService = teamService; }

        [HttpGet]
        public async Task<List<TeamDTO>> GetAllTeams() { return await _teamService.GetTeamsAsync(); }

        [HttpGet("{id}")]
        public async Task<TeamDTO> GetTeamById(string id) { return await _teamService.GetTeamById(id); }

        [HttpGet("players")]
        public async Task<List<PlayerDTO>>GetTeamPlayers([FromQuery]string teamId) { return await _teamService.GetTeamPlayers(teamId); }

        [HttpGet("players/{playerId}")]
        public async Task<PlayerDTO> GetTeamPlayerById([FromRoute]string teamId, [FromRoute]string playerId) { return await _teamService.GetTeamPlayerById(teamId, playerId); }

        [HttpPut("{teamId}")] // !!! only works if team manager has only one team !!!
        public async Task<TeamDTO>UpdateTeamInfo([FromRoute] string teamId, [FromBody] TeamDTO dto) { return await _teamService.UpdateTeamInfo(teamId, dto); }

        [HttpPut("{teamId}/players")]  // can only add/modify/remove one player at a time
        public async Task<TeamDTO> UpdateTeamPlayers([FromRoute] string teamId,[FromBody] TeamDTO dto) { return await _teamService.UpdatePlayerList(teamId, dto); }

        [HttpGet("tournaments/upcoming")]
        public async Task<List<TournamentDTO>> GetUpcomingTeamTournaments([FromQuery]string teamId) { return await _teamService.GetUpcomingTournaments(teamId); }
        [HttpGet("tournaments")]
        public async Task<List<TournamentDTO>> GetCurrentTeamTournaments([FromQuery]string teamId) { return await _teamService.GetOngoingTournaments(teamId); }
        [HttpGet("tournaments/past")]
        public async Task<List<TournamentDTO>> GetPastTeamTournaments([FromQuery]string teamId) { return await _teamService.GetPastTournaments(teamId); }
        [HttpGet("matches/upcoming")]
        public async Task<List<TeamMatchDTO>> GetUpcomingTeamMatches([FromQuery]string teamId) { return await _teamService.GetUpcomingMatches(teamId); }
        [HttpGet("matches/past")]
        public async Task<List<TeamMatchDTO>> GetPastTeamMatches([FromQuery]string teamId) { return await _teamService.GetPastMatches(teamId); }

        // no functionality

        [HttpPost]
        public async Task<TeamDTO> Post([FromBody]TeamDTO dto) { return dto; }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] string id) { }
    }
}
