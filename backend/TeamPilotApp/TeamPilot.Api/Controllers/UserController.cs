using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Dtos.UserDtos;
using TeamPilot.Application.Services;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<List<UserWithNullablePlayerPropsDTO>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserWithNullablePlayerPropsDTO> GetUserAsync([FromRoute] string id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        [HttpGet("{id}/followedPlayers")]
        public async Task<List<UserWithNullablePlayerPropsDTO>> GetFollowedPlayersAsync([FromRoute] string id)
        {
            return await _userService.GetFollowedPlayersAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<UserWithNullablePlayerPropsDTO> UpdateUserAsync([FromRoute] string id, [FromBody] UserWithNullablePlayerPropsDTO dto)
        {
            return await _userService.UpdateUserAsync(dto);
        }
        [HttpDelete("{id}")]
        public async Task DeleteRegisteredUser([FromRoute] string id)
        {
            bool isDeleted = await _userService.DeleteRegisteredUserAsync(id);
        }
        [HttpGet("player/tournaments-and-matches/{playerId}")]
        public async Task<List<TournamentMatchDTO>> GetPlayerTournamentsAndMatchesAsync([FromRoute] string playerId)
        {
            return await _userService.GetPlayerTournamentsAndMatchesAsync(playerId);
        }

        [HttpGet("tournament-manager/tournaments-and-matches/{tournamentManagerId}")]
        public async Task<List<TournamentMatchDTO>> GetTournamentManagerTournamentsAndMatchesAsync([FromRoute] string tournamentManagerId)
        {
            return await _userService.GetTournamentManagerTournamentsAndMatchesAsync(tournamentManagerId);
        }

        [HttpGet("team-manager/tournaments-and-matches/{teamManagerId}")]
        public async Task<List<TournamentMatchDTO>> GetTeamManagerTournamentsAndMatchesAsync([FromRoute] string teamManagerId)
        {
            return await _userService.GetTeamManagerTournamentsAndMatchesAsync(teamManagerId);
        }

        [HttpPost("{userId}/follow/{itemType}/{itemId}")]
        public async Task AddFollowFromItemToRegisteredUser(string userId, string itemId, string itemType)
        {
                await _userService.AddFollowFromItemToRegisteredUser(userId, itemId, itemType);
        }

        [HttpDelete("{userId}/unfollow/{itemType}/{itemId}")]
        public async Task DeleteFollowFromItemToRegisteredUser(string userId, string itemId, string itemType)
        {
            await _userService.DeleteFollowFromItemToRegisteredUser(userId, itemId, itemType);
        }

        [HttpDelete("{userId}/unfollowAll")]
        public async Task DeleteAllFollowsForRegisteredUser(string userId)
        {
            await _userService.DeleteAllFollowsForRegisteredUser(userId);
        }

    }
}