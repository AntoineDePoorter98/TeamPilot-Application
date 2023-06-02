using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Dtos.UserDtos;
using TeamPilot.Application.Extensions;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Services
{
    public class UserService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IRegisteredUserRepository _registeredUserRepository;
        private readonly ITeamManagerRepository _teamManagerRepository;
        private readonly ITournamentManagerRepository _tournamentManagerRepository;

        public UserService(IPlayerRepository playerRepository, IRegisteredUserRepository registeredUserRepository, ITeamManagerRepository teamManagerRepository, ITournamentManagerRepository tournamentManagerRepository)
        {
            _playerRepository = playerRepository;
            _registeredUserRepository = registeredUserRepository;
            _teamManagerRepository = teamManagerRepository;
            _tournamentManagerRepository = tournamentManagerRepository;
        }

        #region Public Methods

        public async Task<List<UserWithNullablePlayerPropsDTO>> GetAllUsersAsync()
        {
            var allUsersDto = await GetListOfAllUsersDtosAsync();

            return allUsersDto;
        }

        public async Task<UserWithNullablePlayerPropsDTO> GetUserByIdAsync(string id)
        {
            return await SelectUserByIdAsync(id);
        }

        public async Task<List<UserWithNullablePlayerPropsDTO>> GetFollowedPlayersAsync(string userId)
        {
            var players = await _registeredUserRepository.GetFollowedPlayersAsync(userId);
            return players.Select(player => player.MapUserEntityToUserDto()).ToList();

        }


        public async Task<UserWithNullablePlayerPropsDTO> UpdateUserAsync(UserWithNullablePlayerPropsDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException(nameof(userDTO));
            }

            var existingUserDto = await GetUserByIdAsync(userDTO.UserId);
            if (existingUserDto == null)
            {
                throw new InvalidOperationException($"User not found with id: {userDTO.UserId}");
            }

            switch (existingUserDto.UserType)
            {
                case "Player":
                    var player = await _playerRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == existingUserDto.UserId);
                    player.FirstName = userDTO.FirstName;
                    player.LastName = userDTO.LastName;
                    player.Email = userDTO.Email;
                    player.Nickname = userDTO.Nickname;
                    player.AvatarUrl = userDTO.AvatarUrl;
                    player.Bio = userDTO.Bio;
                    player.MonthlySalary = (decimal)userDTO.MonthlySalary;
                    player.TeamId = Guid.Parse(userDTO.TeamId);
                    await _playerRepository.UpdateAsync(player);
                    break;
                case "RegisteredUser":
                    var registeredUser = await _registeredUserRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == existingUserDto.UserId);
                    registeredUser.FirstName = userDTO.FirstName;
                    registeredUser.LastName = userDTO.LastName;
                    registeredUser.Email = userDTO.Email;
                    registeredUser.Nickname = userDTO.Nickname;
                    registeredUser.AvatarUrl = userDTO.AvatarUrl;
                    registeredUser.Bio = userDTO.Bio;
                    await _registeredUserRepository.UpdateAsync(registeredUser);
                    break;
                case "TeamManager":
                    var teamManager = await _teamManagerRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == existingUserDto.UserId);
                    teamManager.FirstName = userDTO.FirstName;
                    teamManager.LastName = userDTO.LastName;
                    teamManager.Email = userDTO.Email;
                    teamManager.Nickname = userDTO.Nickname;
                    teamManager.AvatarUrl = userDTO.AvatarUrl;
                    teamManager.Bio = userDTO.Bio;
                    await _teamManagerRepository.UpdateAsync(teamManager);
                    break;
                case "TournamentManager":
                    var tournamentManager = await _tournamentManagerRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == existingUserDto.UserId);
                    tournamentManager.FirstName = userDTO.FirstName;
                    tournamentManager.LastName = userDTO.LastName;
                    tournamentManager.Email = userDTO.Email;
                    tournamentManager.Nickname = userDTO.Nickname;
                    tournamentManager.AvatarUrl = userDTO.AvatarUrl;
                    tournamentManager.Bio = userDTO.Bio;
                    await _tournamentManagerRepository.UpdateAsync(tournamentManager);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid user type: {existingUserDto.UserType}");
            }

            return userDTO;
        }

        public async Task<bool> DeleteRegisteredUserAsync(string id)
        {
            var user = await SelectRegisteredUserByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            await _registeredUserRepository.DeleteAsync(user);

            return true;
        }

        public async Task<List<TournamentMatchDTO>> GetPlayerTournamentsAndMatchesAsync(string playerId)
        {
            var player = await _playerRepository.GetPlayerTournamentsAndMatchesAsync(playerId);

            if (player == null)
            {
                throw new InvalidOperationException($"Player not found with id: {playerId}");
            }

            var data = player.Team.Matches.Select(match => (match.Tournament, match)).ToList();

            return UserHelper.MapToDto(data);
        }

        public async Task<List<TournamentMatchDTO>> GetTournamentManagerTournamentsAndMatchesAsync(string tournamentManagerId)
        {
            var tournamentManager = await _tournamentManagerRepository.GetTournamentManagerTournamentsAndMatchesAsync(tournamentManagerId);

            if (tournamentManager == null)
            {
                throw new InvalidOperationException($"Tournament Manager not found with id: {tournamentManager}");
            }

            var data = tournamentManager.Tournaments
                .SelectMany(tournament => tournament.Matches.Select(match => (tournament, match)))
                .ToList();

            return UserHelper.MapToDto(data);
        }

        public async Task<List<TournamentMatchDTO>> GetTeamManagerTournamentsAndMatchesAsync(string teamManagerId)
        {
            var teamManager = await _teamManagerRepository.GetTeamManagerTournamentsAndMatchesAsync(teamManagerId);

            if (teamManager == null)
            {
                throw new InvalidOperationException($"Team Manager not found with id: {teamManager}");
            }

            var data = teamManager.Teams
                .SelectMany(team => team.Matches.Select(match => (match.Tournament, match)))
                .ToList();

            return UserHelper.MapToDto(data);
        }

        public async Task AddFollowFromItemToRegisteredUser(string userId, string itemId, string itemType)
        {
            if (itemType != "Team" && itemType != "Player" && itemType != "Tournament")
            {
                throw new Exception("Invalid item type.");
            }

            await _registeredUserRepository.AddFollowFromItemToRegisteredUser(userId, itemId, itemType);
        }

        public async Task DeleteFollowFromItemToRegisteredUser(string userId, string itemId, string itemType)
        {
            if (itemType != "Team" && itemType != "Player" && itemType != "Tournament")
            {
                throw new Exception("Invalid item type.");
            }

            await _registeredUserRepository.DeleteFollowFromItemToRegisteredUser(userId, itemId, itemType);
        }

        public async Task DeleteAllFollowsForRegisteredUser(string userId)
        {
            await _registeredUserRepository.DeleteAllFollowsForRegisteredUser(userId);
        }


        #endregion

        #region Private Methods

        private async Task<List<UserWithNullablePlayerPropsDTO>> GetListOfAllUsersDtosAsync()
        {
            var allUsers = new List<UserWithNullablePlayerPropsDTO>();

            var teamManagers = await _teamManagerRepository.GetAllAsync();
            var tournamentManagers = await _tournamentManagerRepository.GetAllAsync();
            var registeredUsers = await _registeredUserRepository.GetAllAsync();
            var players = await _playerRepository.GetAllAsync();

            allUsers.AddRange(teamManagers.Select(UserHelper.MapUserEntityToUserDto));
            allUsers.AddRange(tournamentManagers.Select(UserHelper.MapUserEntityToUserDto));
            allUsers.AddRange(registeredUsers.Select(UserHelper.MapUserEntityToUserDto));
            allUsers.AddRange(players.Select(UserHelper.MapUserEntityToUserDto));

            return allUsers;
        }

        private async Task<UserWithNullablePlayerPropsDTO> SelectUserByIdAsync(string id)
        {
            var player = await _playerRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == id);
            var registeredUser = await _registeredUserRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == id);
            var teamManager = await _teamManagerRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == id);
            var tournamentManager = await _tournamentManagerRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == id);

            if (player != null)
            {
                return UserHelper.MapUserEntityToUserDto(player);
            }
            else if (registeredUser != null)
            {
                return UserHelper.MapUserEntityToUserDto(registeredUser);
            }
            else if (teamManager != null)
            {
                return UserHelper.MapUserEntityToUserDto(teamManager);
            }
            else if (tournamentManager != null)
            {
                return UserHelper.MapUserEntityToUserDto(tournamentManager);
            }
            else
            {
                throw new InvalidOperationException($"User not found with id: {id}");
            }
        }

        private async Task<RegisteredUser> SelectRegisteredUserByIdAsync(string id)
        {
            var registeredUser = await _registeredUserRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == id);

            if (registeredUser != null)
            {
                return registeredUser;
            }

            else
            {
                throw new InvalidOperationException($"User not found with id: {id}");
            }
        }

        #endregion

    }
}
