using System.Diagnostics.CodeAnalysis;
using TeamPilot.Application.Dtos.team;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Exceptions;
using TeamPilot.Application.ExtensionMethods;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;
using TeamPilot.Domain.Enums;

namespace TeamPilot.Application.Services
{
    public class TeamService
    {
        private ITeamRepository _teamRepository;
        private IPlayerRepository _playerRepository;
        private readonly CurrentUserService _currentUserService;

        public TeamService(ITeamRepository teamRepository,
            CurrentUserService currentUserService,
            IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _currentUserService = currentUserService;
            _playerRepository = playerRepository;
        }

        private async Task<Team> GetManagerTeamEntity(string teamid)
        {
            var user = _currentUserService.CurrentUser;
            //var user = _currentUserService.MockTeamManager; // for tests only!
            Team? team = await _teamRepository.FirstOrDefaultIncludingPlayersAsync(x => x.TeamManagerId == user.UserId);
            if (team == null) throw new UnknownResourceException("No such Team");
            if(team.TeamId != new Guid(teamid)) throw new NoAccessException("Illegal operation");
            return team;
        }

        private async Task<Team> GetTeamEntityById(string teamId) 
        {
            Team? team = await _teamRepository.FirstOrDefaultIncludingPlayersAsync(x => x.TeamId == new Guid(teamId));
            if (team == null) throw new UnknownResourceException("No such Team");
            return team;
        }
        private async Task<Player> GetPlayerToUpdate(string playerToUpdateId)
        {
            Player? playerToUpdate = await _playerRepository.FirstOrDefaultAsync(x => x.UserId.ToString().ToUpper() == playerToUpdateId.ToString().ToUpper());
            if (playerToUpdate == null) throw new UnknownResourceException("No such Player");
            return playerToUpdate;
        }
        private async Task<List<Tournament>> GetAllTournamentsIncludingMatchesAndTeamMatches() { return await _teamRepository.GetAllTournamentsIncludingMatchesAndTeamMatches(); }

        private List<Tournament> FilterTournamentListForParticipatingTeam(Team team, List<Tournament> originalTournamentList)
        {
            List<Tournament> filteredTournaments = new List<Tournament>();

            foreach (var turn in originalTournamentList)
            {
                foreach (var match in turn.Matches)
                {
                    foreach (var t in match.Teams)
                    {
                        if (t.TeamId == team.TeamId)
                        {
                            filteredTournaments.Add(turn);
                            break;
                        }
                    }
                }
            }
            return filteredTournaments;
        }

        // team crud - get / get by / put
        public async Task<List<TeamDTO>> GetTeamsAsync(){
            List<Team> teamEntities = await _teamRepository.GetAllTeamsIncludingPlayers();
            List<TeamDTO> teamsToReturn = new List<TeamDTO>();
            foreach (Team team in teamEntities) { TeamDTO teamToAdd = TeamMapper.EntityToDTO(team); teamsToReturn.Add(teamToAdd); }
            return teamsToReturn;
        }

        public async Task<TeamDTO> GetTeamById(string id)
        {
            Team? team = await _teamRepository.FirstOrDefaultIncludingPlayersAsync(x => x.TeamId.ToString().ToUpper() == id.ToUpper());
            if (team == null) throw new UnknownResourceException("No such Team");
            return TeamMapper.EntityToDTO(team);
        }

        public async Task<List<PlayerDTO>> GetTeamPlayers(string teamid) 
        {
            Team? team = await GetTeamEntityById(teamid);
            List<Player> players = team.Players;
            if (players == null)
            {
                return new List<PlayerDTO>();
            }
            List<PlayerDTO> playerListToReturn = new List<PlayerDTO>();
            foreach (Player player in players) { playerListToReturn.Add(PlayerMapper.EntityToDTO(player)); }
            return playerListToReturn;
        }

        public async Task<TeamDTO> GetManagerTeam(string teamId)
        {
            Team? team = await GetManagerTeamEntity(teamId);
            return TeamMapper.EntityToDTO(team);
        }

        // this one is not going to be used so long as a team manager is only allowed to manage one team
        public async Task<List<Team>> GetManagerTeams()
        {
            List<Team> teams = await _teamRepository.FindManyAsync(c => c.TeamManagerId == _currentUserService.MockTeamManager.UserId);
            return teams;
        }

        public async Task<PlayerDTO> GetTeamPlayerById(string teamid, string playerId) 
        {
            Team? team = await GetManagerTeamEntity(teamid);
            Player playerToReturn = team.Players.Where(x=>x.UserId == new Guid(playerId)).FirstOrDefault();
            if (playerToReturn == null) throw new UnknownResourceException("No such player in team"); 
            return PlayerMapper.EntityToDTO(playerToReturn);
        }

        public async Task<TeamDTO> UpdateTeamInfo(string teamid, TeamDTO teamDTO) // !!! only works if team manager has only one team !!!
        {
            Team? team = await GetManagerTeamEntity(teamid);

           if (teamDTO.TeamId==null||teamDTO.TeamId=="") teamDTO.TeamId = team.TeamId.ToString();
           if(teamDTO.TeamManagerId == null||teamDTO.TeamManagerId=="") teamDTO.TeamManagerId = team.TeamManagerId.ToString();
           if (teamDTO.TeamName == null || teamDTO.TeamName == "") teamDTO.TeamName = team.TeamName;
           if(teamDTO.AvatarUrl == null || teamDTO.AvatarUrl == "") teamDTO.AvatarUrl = team.AvatarUrl;
           
            Team teamToUpdate = TeamMapper.DTOToEntity(teamDTO);
            
            if(teamDTO.Players == null) 
           {
                teamToUpdate.Players = new List<Player>();

                if (team.Players != null)
                {
                    teamToUpdate.Players = team.Players.ToList();
                }
           }

            await _teamRepository.UpdateAsync(teamToUpdate);

            return TeamMapper.EntityToDTO(teamToUpdate);
        }

        // team player crud - get / get by /put

        public async Task<TeamDTO> UpdatePlayerList(string teamId, TeamDTO teamDTO) // can only add/modify/remove one player at a time
        {
            Team? team = await GetManagerTeamEntity(teamId);

            if(teamDTO.Players == null) { teamDTO.Players = new List<PlayerDTO>(); }

            PlayerUpdateEnum updateType = new PlayerUpdateEnum();

            Player playerToUpdate = new Player();

            if (teamDTO.Players.Count == team.Players.Count) { updateType = PlayerUpdateEnum.Modify; }
            if (teamDTO.Players.Count > team.Players.Count) { updateType = PlayerUpdateEnum.Add; }
            if (teamDTO.Players.Count < team.Players.Count) { updateType = PlayerUpdateEnum.Remove; }

            switch (updateType.GetHashCode())
            {
                case 0: 
                  {
                        string userId = "";
                        decimal newSalary = 0M;
                    foreach (var newPlayer in teamDTO.Players)
                    {
                            decimal trySalary=0;
                            bool isSalary = Decimal.TryParse(newPlayer.MonthlySalary, out trySalary);
                            if (!isSalary || trySalary < 0) throw new IllegalFieldFoundException("Invalid salary value");

                            var tryId = team.Players?.Where(x => x.UserId == new Guid(newPlayer.UserId) && x.MonthlySalary != trySalary).Select(x => x.UserId.ToString()).FirstOrDefault();
                            if (tryId != null) { userId = tryId; newSalary = trySalary; }
                    }
                            playerToUpdate = await GetPlayerToUpdate(userId);
                            playerToUpdate.MonthlySalary = newSalary;
                  } break;

                case 1: 
                  {
                     List<Guid> oldIds = new List<Guid>();
                        foreach (Player originalPlayer in team.Players)
                         {
                              oldIds.Add(originalPlayer.UserId);
                         }

                    string newId = "";
                    string salaryToUpdate = "";

                    foreach (PlayerDTO newPlayer in teamDTO.Players)
                    {
                        if (!oldIds.Contains(new Guid(newPlayer.UserId))) { newId = newPlayer.UserId; salaryToUpdate = newPlayer.MonthlySalary; }
                    }
                        playerToUpdate = await GetPlayerToUpdate(newId);
                        playerToUpdate.TeamId = team.TeamId;

                            decimal newSalary = 0;
                            bool isSalary = Decimal.TryParse(salaryToUpdate, out newSalary);
                            if (!isSalary || newSalary < 0) throw new IllegalFieldFoundException("Invalid salary value");

                        playerToUpdate.MonthlySalary = newSalary;
                  }
                break;

                case 2: 
                  {
                        List<Guid> newIds = new List<Guid>();
                        foreach (PlayerDTO item in teamDTO.Players)
                        {
                            newIds.Add(new Guid(item.UserId));
                        }
                        foreach (Player player in team.Players)
                        {
                        if (!newIds.Contains(player.UserId)) { playerToUpdate = await GetPlayerToUpdate(player.UserId.ToString()); }
                        }
                        playerToUpdate.MonthlySalary = 0M;
                        playerToUpdate.TeamId = null;
                    }
                    break;
            }

            await _playerRepository.UpdateAsync(playerToUpdate);

            Team? newTeam = await GetManagerTeamEntity(teamId);
            TeamDTO updatedTeam = new TeamDTO();
            if (newTeam == null) throw new Exception("Something went wrong");

            updatedTeam = TeamMapper.EntityToDTO(newTeam);
            return updatedTeam;
        }

        // team tournament / match crud - get all

        public async Task<List<TeamMatchDTO>> GetUpcomingMatches(string teamId)
        {
            Team? team = await GetTeamEntityById(teamId);
            List<Tournament> tournaments = await GetAllTournamentsIncludingMatchesAndTeamMatches();

            List<Match> matches = new List<Match>();

            foreach (var turn in tournaments)
            {
                foreach (var match in turn.Matches)
                {
                    foreach (var t in match.Teams)
                    {
                       // if (t.TeamId == team.TeamId && match.Date > DateTime.Parse("2023-05-12"))
                        if (t.TeamId == team.TeamId && match.Date > DateTime.Today)
                        {
                            matches.Add(match);
                        }
                    }
                }
            }

            List<TeamMatchDTO> matchesToReturn = new List<TeamMatchDTO>();
            matches.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            foreach (var m in matches)
            {
                Tournament tournamentDetail = tournaments?.Find(x => x.TournamentId == m.TournamentId) ?? new Tournament();
                matchesToReturn.Add(TeamMapper.MatchEntityToTeamMatchDTOMapper(m, tournamentDetail));
            }
            return matchesToReturn;
        }

        public async Task<List<TeamMatchDTO>> GetPastMatches(string teamId)
        {
            Team? team = await GetTeamEntityById(teamId);
            List<Tournament> tournaments = await GetAllTournamentsIncludingMatchesAndTeamMatches();

            List<Match> matches = new List<Match>();

            foreach (var turn in tournaments)
            {
                foreach (var match in turn.Matches)
                {
                    foreach (var t in match.Teams)
                    {
                        if (t.TeamId == team.TeamId && match.Date < DateTime.Today)
                        {
                            matches.Add(match);
                        }
                    }
                }
            }
            List<TeamMatchDTO> matchesToReturn = new List<TeamMatchDTO>();
            matches.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            foreach (var m in matches) 
            { 
                Tournament tournamentDetail = tournaments?.Find(x => x.TournamentId == m.TournamentId)?? new Tournament();
                matchesToReturn.Add(TeamMapper.MatchEntityToTeamMatchDTOMapper(m, tournamentDetail)); 
            }
            return matchesToReturn;
        }

        public async Task<List<TournamentDTO>> GetUpcomingTournaments(string teamId)
        {
            Team? team = await GetTeamEntityById(teamId);
            List<Tournament> allTournaments = await GetAllTournamentsIncludingMatchesAndTeamMatches();

            List<Tournament> filteredTournaments = FilterTournamentListForParticipatingTeam(team, allTournaments);
            
            filteredTournaments = filteredTournaments.Where(x => x.StartDate > DateTime.Today).Distinct().ToList();
            filteredTournaments.Sort((x, y) => DateTime.Compare(x.StartDate, y.StartDate));
            List<TournamentDTO> tournamentssToReturn = new List<TournamentDTO>();
            foreach (var tournament in filteredTournaments) { tournamentssToReturn.Add(TournamentExtensionMethods.TournamentEntityToDTOMapper(tournament)); }
            foreach (TournamentDTO turn in tournamentssToReturn) { turn.FutureTournamentMatches.Sort((a, b) => DateTime.Compare(DateTime.Parse(a.MatchDate), DateTime.Parse(b.MatchDate))); };
            return tournamentssToReturn;
        }

        public async Task<List<TournamentDTO>> GetOngoingTournaments(string teamId)
        {
            Team? team = await GetTeamEntityById(teamId);
            List<Tournament> allTournaments = await GetAllTournamentsIncludingMatchesAndTeamMatches();

            List<Tournament> filteredTournaments = FilterTournamentListForParticipatingTeam(team, allTournaments);

           // filteredTournaments = filteredTournaments.Where(x => x.StartDate < DateTime.Today && x.EndDate > DateTime.Parse("2023-05-20")).Distinct().ToList();
            filteredTournaments = filteredTournaments.Where(x => x.StartDate < DateTime.Today && x.EndDate > DateTime.Today).Distinct().ToList();
            filteredTournaments.Sort((x, y) => DateTime.Compare(x.StartDate, y.StartDate));
            List<TournamentDTO> tournamentssToReturn = new List<TournamentDTO>();
            foreach (var tournament in filteredTournaments) { tournamentssToReturn.Add(TournamentExtensionMethods.TournamentEntityToDTOMapper(tournament)); }
            foreach (TournamentDTO turn in tournamentssToReturn) { turn.FutureTournamentMatches.Sort((a, b) => DateTime.Compare(DateTime.Parse(a.MatchDate), DateTime.Parse(b.MatchDate))); };
            return tournamentssToReturn;
        }

        public async Task<List<TournamentDTO>> GetPastTournaments(string teamId)
        {
            Team? team = await GetTeamEntityById(teamId);
            List<Tournament> allTournaments = await GetAllTournamentsIncludingMatchesAndTeamMatches();

            List<Tournament> filteredTournaments = FilterTournamentListForParticipatingTeam(team, allTournaments);

            filteredTournaments = filteredTournaments.Where(x => x.EndDate < DateTime.Today).Distinct().ToList();
            filteredTournaments.Sort((x, y) => DateTime.Compare(x.StartDate, y.StartDate));
            List<TournamentDTO> tournamentssToReturn = new List<TournamentDTO>();
            foreach (var tournament in filteredTournaments) { tournamentssToReturn.Add(TournamentExtensionMethods.TournamentEntityToDTOMapper(tournament)); }
            foreach (TournamentDTO turn in tournamentssToReturn) { turn.PastTournamentMatches.Sort((a, b) => DateTime.Compare(DateTime.Parse(a.MatchDate), DateTime.Parse(b.MatchDate))); };
            return tournamentssToReturn;
        }
    }
}
