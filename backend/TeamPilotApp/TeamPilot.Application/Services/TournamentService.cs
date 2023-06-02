using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Exceptions;
using TeamPilot.Application.ExtensionMethods;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Services
{
    public class TournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly CurrentUserService _currentUserService;
        private readonly User _currentUser;

        public TournamentService(ITournamentRepository tournamentRepository, ITeamRepository teamRepository, CurrentUserService currentUserService)
        {
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
            _currentUserService = currentUserService;
            _currentUser = _currentUserService.CurrentUser;
        }

        #region Get All Tournaments For List Page

        public async Task<List<TournamentDTO>> GetAllTournaments()
        {
            var listOfTournaments = await _tournamentRepository.GetAllTournamentsAsync();
            var convertedListOfTournaments =
                TournamentExtensionMethods.MultipleTournamentEntitiesToDTOsMapper(listOfTournaments);
            if (convertedListOfTournaments == null)
            {
                throw new Exception("Internal server error");
            }
            return convertedListOfTournaments;
        }

        #endregion

        #region Get All Tournaments For Tournament Manager

        public async Task<List<TournamentForManagerDTO>> GetAllTournamentsForManager(string tournamentManagerId)
        {
            if (tournamentManagerId == null)
            {
                throw new UnknownResourceException();
            }
            else if (Guid.TryParse(tournamentManagerId, out Guid _) == false)
            {
                throw new IllegalFieldFoundException("This tournament ID is not valid");
            }

            var tournamentsForManager =
                await _tournamentRepository.GetTournamentsForTournamentManager(Guid.Parse(tournamentManagerId));
            var tournamentsToReturn =
                TournamentExtensionMethods.MultipleTournamentEntitiesToManagerDTOsMapper(tournamentsForManager);
            return tournamentsToReturn;
        }

        #endregion

        #region Get a Single Tournament With All Calculations

        public async Task<TournamentDTO> GetTournamentByID(string tournamentId)
        {
            if (tournamentId == null)
            {
                throw new UnknownResourceException();
            }
            else if (Guid.TryParse(tournamentId, out Guid _) == false)
            {
                throw new IllegalFieldFoundException("This tournament ID is not valid");
            }

            var tournament = await _tournamentRepository.GetTournamentByIDAsync(Guid.Parse(tournamentId));
            if (tournament != null)
            {
                if (tournament.StartDate < DateTime.Today)
                {
                    var matchesWithWinners = await CalculateWinnerOfEachMatchInTournament(tournament.Matches);
                    Dictionary<Guid, int> tournamentTeamWins = new();
                    foreach (var match in matchesWithWinners)
                    {
                        if (tournamentTeamWins.ContainsKey(match.WinningTeamId))
                        {
                            tournamentTeamWins[match.WinningTeamId]++;
                        }
                        else
                        {
                            tournamentTeamWins[match.WinningTeamId] = 1;
                        }
                    }

                    var tournamentWinner = tournamentTeamWins.OrderByDescending(x => x.Value).FirstOrDefault().Key;
                    tournament.Matches = matchesWithWinners;
                    tournament.WinningTeamId = tournamentWinner;
                }
                var convertedTournament = TournamentExtensionMethods.TournamentEntityToDTOMapper(tournament);
                return convertedTournament;
            }
            throw new UnknownResourceException("Tournament not found");
        }

        private async Task<List<Match>> CalculateWinnerOfEachMatchInTournament(List<Match> matches)
        {
            foreach (var match in matches.OrderByDescending(x => x.Date))
            {
                if (match.Date > DateTime.Today)
                {
                    continue;
                }
                
                var team1 = match.Teams[0];
                var team2 = match.Teams[1];

                ProcessMatch(match, team1, team2);
            }

            return matches;
        }

        private void ProcessMatch(Match match, Team team1, Team team2)
        {
            int team1RoundWins = 0;
            int team2RoundWins = 0;

            while (team1RoundWins < 5 && team2RoundWins < 5)
            {
                foreach (var round in match.Rounds)
                {
                    ProcessRound(round, team1, team2, ref team1RoundWins, ref team2RoundWins);
                }

                if (team1RoundWins == 5)
                {
                    match.WinningTeamId = team1.TeamId;
                }
                else if (team2RoundWins == 5)
                {
                    match.WinningTeamId = team2.TeamId;
                }
            }
        }

        private void ProcessRound(Round round, Team team1, Team team2, ref int team1RoundWins, ref int team2RoundWins)
        {
            int team1Kills = 0;
            int team2Kills = 0;

            while (team1Kills < 1 && team2Kills < 1)
            {
                if(round.RoundEvents.Count > 0)
                {
                    foreach (var roundEvent in round.RoundEvents.OrderByDescending(x => x.TimeStamp))
                    {
                        ProcessRoundEvent(roundEvent, team1, team2, ref team1Kills, ref team2Kills);
                    }

                    if (team1Kills == 1)
                    {
                        round.TeamWinnerId = team1.TeamId;
                        team1RoundWins++;
                    }
                    else if (team2Kills == 1)
                    {
                        round.TeamWinnerId = team2.TeamId;
                        team2RoundWins++;
                    }
                }
                else
                {
                    team1Kills++;
                }
            }
        }
        
        private void ProcessRoundEvent(RoundEvent roundEvent, Team team1, Team team2, ref int team1Kills, ref int team2Kills)
        {
            if (roundEvent.KillingPlayer.TeamId == team1.TeamId)
            {
                team1Kills++;
            }
            else if (roundEvent.KillingPlayer.TeamId == team2.TeamId)
            {
                team2Kills++;
            }
        }

        #endregion

        #region Create a Tournament

        public async Task<List<TeamForTournamentDTO>> GetTeamsToSelectForTournament()
        {
            var teams = await _teamRepository.GetAllAsync();
            var convertedTeams = TournamentExtensionMethods.MultipleTeamEntitiesToDTOsMapper(teams);
            return convertedTeams;
        }

        public async Task CreateANewTournament(NewTournamentDTO newTournamentDTO)
        {
            ValidateTournamentDetails(newTournamentDTO);

            var newTournament = TournamentExtensionMethods.NewTournamentDTOToEntityMapper(newTournamentDTO, _currentUser.UserId);
            var differenceInDates = newTournament.EndDate - newTournament.StartDate;
            var differenceInDays = -differenceInDates.TotalDays;
            await _tournamentRepository.CreateTournamentAsync(newTournament);

            foreach (var team in newTournamentDTO.TournamentParticipatingTeams)
            {
                await _tournamentRepository.AddTeamsToTournamentRaw(newTournament.TournamentId.ToString(), team.TeamId);
            }
        }

        #endregion

        #region Update a Tournament

        public async Task UpdateAnExistingTournament(NewTournamentDTO newTournamentDTO)
        {
            ValidateTournamentDetails(newTournamentDTO);

            var tournament = TournamentExtensionMethods.NewTournamentDTOToEntityMapper(newTournamentDTO, _currentUser.UserId);
            tournament.TournamentId = Guid.Parse(newTournamentDTO.TournamentId);
            await _tournamentRepository.DeleteTeamsForTournamentRaw(tournament.TournamentId.ToString());
            foreach (var team in newTournamentDTO.TournamentParticipatingTeams)
            {
                await _tournamentRepository.AddTeamsToTournamentRaw(tournament.TournamentId.ToString(), team.TeamId);
            }
            await _tournamentRepository.UpdateTournamentAsync(tournament);
        }

        #endregion

        #region Delete a Tournament

        public async Task DeleteAnExistingTournament(string tournamentId)
        {
            if (tournamentId == null)
            {
                throw new UnknownResourceException();
            }
            else if (Guid.TryParse(tournamentId, out Guid _) == false)
            {
                throw new IllegalFieldFoundException("This tournament ID is not valid");
            }

            await _tournamentRepository.DeleteTournamentAsync(Guid.Parse(tournamentId));
        }

        #endregion

        #region Tournament Validation

        private void ValidateTournamentDetails(NewTournamentDTO newTournamentDTO)
        {
            if (string.IsNullOrEmpty(newTournamentDTO.TournamentName))
                throw new IllegalFieldFoundException("Tournament name cannot be empty");
            if (string.IsNullOrEmpty(newTournamentDTO.TournamentFormat))
                throw new IllegalFieldFoundException("Tournament format cannot be empty");
            if (newTournamentDTO.TournamentPrizePool <= 1000M || newTournamentDTO.TournamentPrizePool == null)
                throw new IllegalFieldFoundException("Tournament prize pool cannot be empty and must be above $1000");
            if (string.IsNullOrEmpty(newTournamentDTO.TournamentLocation))
                throw new IllegalFieldFoundException("Tournament location cannot be empty");
            if (string.IsNullOrEmpty(newTournamentDTO.TournamentSponsor))
                throw new IllegalFieldFoundException("Tournament sponsor cannot be empty");
            if (string.IsNullOrEmpty(newTournamentDTO.TournamentStartDate))
                throw new IllegalFieldFoundException("Tournament start date cannot be empty");
            if (string.IsNullOrEmpty(newTournamentDTO.TournamentEndDate))
                throw new IllegalFieldFoundException("Tournament end date cannot be empty");
            if (newTournamentDTO.TournamentParticipatingTeams.Count != 8 && newTournamentDTO.TournamentParticipatingTeams.Count != 16 && newTournamentDTO.TournamentParticipatingTeams.Count != 32)
            {
                throw new IllegalFieldFoundException(
                    "Tournament should have 8, 16 or 32 teams");
            }
        }

        #endregion
    }
}
