using TeamPilot.Application.Dtos.team;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Exceptions;
using TeamPilot.Application.Services;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Tests
{
    public class TeamServiceTests
    {
        private readonly TeamService _teamService;

        private const string TEAMID = "e4c5d733-5afd-43e4-af70-1f3f0f2a2389";

        public TeamServiceTests(TeamService teamService)
        {
            _teamService = teamService;
        }
        
        [Fact]
        public async Task GetAllTeams()
        {
            List<TeamDTO> teams = await _teamService.GetTeamsAsync();

            Assert.NotNull(teams);
            Assert.NotNull(teams[1].Players);
            Assert.Equal("e4c5d733-5afd-43e4-af70-1f3f0f2a2389", teams[3].TeamId.ToString());
            Assert.Equal(16, teams.Count());
            Assert.Equal("Pavle", teams?[1].Players?[3].FirstName??"");
        }

        [Fact]
        public async Task GetTeamById()
        {
            TeamDTO team = await _teamService.GetTeamById("94e037c5-fff8-4753-a148-01024971feea");

            Assert.NotNull(team);
            Assert.NotNull(team.Players);
            Assert.Equal("OG", team.TeamName);
            Assert.Equal("NEOFRAG", team.Players.Last().Nickname);
        }

        [Fact]
        public async Task GetTeamByWrongId()
        {
            Func<Task> act = async () => await _teamService.GetTeamById("bd4a22ee-a37f-4179-9693-03bd8845047c");
            UnknownResourceException exception = await Assert.ThrowsAsync<UnknownResourceException>(act);

            Assert.Equal("No such Team", exception.Message);
        }

        [Fact]
        public async Task FindManagerTeam()
        {
            TeamDTO team = await _teamService.GetManagerTeam(TEAMID);

            Assert.NotNull(team);
            Assert.Equal("cfd8c76b-e741-405c-8d03-25ce7d6ba5d8", team.TeamManagerId?.ToString()??"");
        }

        [Fact]
        public async Task FindManagerTeams()
        {
            List<Team> teams = await _teamService.GetManagerTeams();

            Assert.NotNull(teams);
            Assert.Equal(1, teams.Count());
        }

        [Fact]
        public async Task GetTeamPlayers()
        {
            List<PlayerDTO> teamPlayers = await _teamService.GetTeamPlayers(TEAMID);

            Assert.NotNull(teamPlayers);
            Assert.Equal("yekindar@liquid.com", teamPlayers.Last().Email);
        }

        [Fact]
        public async Task GetTeamPlayerById() 
        {
            PlayerDTO player = await _teamService.GetTeamPlayerById(TEAMID, "596985ea-3416-4a31-87c1-c1f5e3417862");

            Assert.NotNull(player);
            Assert.Equal("Jablonowski", player.LastName);
        }

        [Fact]
        public async Task GetTeamPlayerByWrongId()
        {
            Func<Task> act = async () => await _teamService.GetTeamPlayerById(TEAMID, "dbd412d4-73ba-46ed-82c5-108701576a60");
            UnknownResourceException exception = await Assert.ThrowsAsync<UnknownResourceException>(act);

            Assert.Equal("No such player in team", exception.Message);
        }

        [Fact]
        public async Task UpdateTeamInfo()
        {
            TeamDTO teamToUpdate = new TeamDTO
            {
                TeamId = "e4c5d733-5afd-43e4-af70-1f3f0f2a2389",
                TeamName = "testLiquid",
            };

            TeamDTO updatedTeam = await _teamService.UpdateTeamInfo(TEAMID, teamToUpdate);

           Assert.NotNull(updatedTeam);
           Assert.Equal("testLiquid", updatedTeam.TeamName);
           Assert.Equal("fifth one of the team", updatedTeam.Players?.Last().Bio??"");
        }

        [Fact]
        public async Task AddPlayerToTeam()
        {
            TeamDTO teamToupdate = new TeamDTO
            {
                TeamId = "e4c5d733-5afd-43e4-af70-1f3f0f2a2389",

                Players = new List<PlayerDTO>
                {
                    new PlayerDTO
                    {
                        UserId = "c8ca7498-308d-489e-aed7-f284bb1d406b",
                        MonthlySalary = "0.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "2740029b-d5f3-4712-91e6-89c51c528ad2",
                        MonthlySalary = "3000.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "76a754d3-a692-4221-a4e5-90c3269dffb8",
                        MonthlySalary = "6700.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "f038a8d1-950a-4a1a-a787-ab7c470f4834",
                        MonthlySalary = "3000.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "596985ea-3416-4a31-87c1-c1f5e3417862",
                        MonthlySalary = "5400.00"
                    }                 
                }
            };

            TeamDTO updatedTeam = await _teamService.UpdatePlayerList(TEAMID, teamToupdate);

            Assert.NotNull(updatedTeam);
            Assert.Equal(5, updatedTeam.Players?.Count??0);
            Assert.Equal("nitr0", updatedTeam.Players?[1].Nickname ?? "");
        }

        [Fact]
        public async Task UpdatePlayerSalary()
        {
            TeamDTO teamToupdate = new TeamDTO
            {
                TeamId = "e4c5d733-5afd-43e4-af70-1f3f0f2a2389",

                Players = new List<PlayerDTO>
                {
                    new PlayerDTO
                    {
                        UserId = "c8ca7498-308d-489e-aed7-f284bb1d406b",
                        MonthlySalary = "1000.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "2740029b-d5f3-4712-91e6-89c51c528ad2",
                        MonthlySalary = "400.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "76a754d3-a692-4221-a4e5-90c3269dffb8",
                        MonthlySalary = "450.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "f038a8d1-950a-4a1a-a787-ab7c470f4834",
                        MonthlySalary = "2500.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "596985ea-3416-4a31-87c1-c1f5e3417862",
                        MonthlySalary = "5400.00"
                    }
                }
            };

            TeamDTO updatedTeam = await _teamService.UpdatePlayerList(TEAMID, teamToupdate);

            Assert.NotNull(updatedTeam);
            Assert.Equal("3000.00", updatedTeam.Players?[2].MonthlySalary ?? "0");
        }

        [Fact]
        public async Task UpdateWrongPlayerSalary()
        {
            TeamDTO teamToupdate = new TeamDTO
            {
                TeamId = "e4c5d733-5afd-43e4-af70-1f3f0f2a2389",

                Players = new List<PlayerDTO>
                {
                    new PlayerDTO
                    {
                        UserId = "c8ca7498-308d-489e-aed7-f284bb1d406b",
                        MonthlySalary = "1000.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "2740029b-d5f3-4712-91e6-89c51c528ad2",
                        MonthlySalary = "400.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "76a754d3-a692-4221-a4e5-90c3269dffb8",
                        MonthlySalary = "-450.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "f038a8d1-950a-4a1a-a787-ab7c470f4834",
                        MonthlySalary = "2500.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "596985ea-3416-4a31-87c1-c1f5e3417862",
                        MonthlySalary = "5400.00"
                    }
                }
            };
            Func<Task> act = async () => await _teamService.UpdatePlayerList(TEAMID, teamToupdate);
            IllegalFieldFoundException exception = await Assert.ThrowsAsync<IllegalFieldFoundException>(act);

            Assert.Equal("Invalid salary value", exception.Message);
        }

        [Fact]

        public async Task RemovePlayerFromTeam()
        {
            TeamDTO teamToupdate = new TeamDTO
            {
                TeamId = "e4c5d733-5afd-43e4-af70-1f3f0f2a2389",

                Players = new List<PlayerDTO>
                {
                    new PlayerDTO
                    {
                        UserId = "2740029b-d5f3-4712-91e6-89c51c528ad2",
                        MonthlySalary = "400.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "76a754d3-a692-4221-a4e5-90c3269dffb8",
                        MonthlySalary = "450.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "f038a8d1-950a-4a1a-a787-ab7c470f4834",
                        MonthlySalary = "2500.00"
                    },
                    new PlayerDTO
                    {
                        UserId = "596985ea-3416-4a31-87c1-c1f5e3417862",
                        MonthlySalary = "5400.00"
                    }
                }
            };
            TeamDTO updatedTeam = await _teamService.UpdatePlayerList(TEAMID, teamToupdate);

            Assert.NotNull(updatedTeam);
            Assert.Equal(4, updatedTeam.Players?.Count ?? 0);
            Assert.Equal("nitr0", updatedTeam.Players?[1].Nickname ?? "");
        }

        // team tournament/match tests

        [Fact]

        public async Task GetAllUpcomingTeamMatches() 
        {
            List<TeamMatchDTO> matches = await _teamService.GetUpcomingMatches(TEAMID);

            Assert.NotNull(matches);
            Assert.Equal(3, matches.Count);
            Assert.Equal("c309e588-4ce5-4c55-8e65-520228b435b7", matches.Last().MatchId);
        }

        [Fact]

        public async Task GetAllPastTeamMatches()
        {
            List<TeamMatchDTO> matches = await _teamService.GetPastMatches(TEAMID);

            Assert.NotNull(matches);
            Assert.Equal(6, matches.Count);
            Assert.Equal("fab96fd5-e43c-4051-813e-95bf69291d9b", matches.Last().MatchId);
        }

        [Fact]

        public async Task GetAllUpcomingTeamTournaments()
        {
            List<TournamentDTO> tournaments = await _teamService.GetUpcomingTournaments(TEAMID);

            Assert.NotNull(tournaments);
            Assert.Equal(1, tournaments?.Count??0);
            Assert.Equal("621d0549-cfb5-481b-88d7-a505babc1db2", tournaments.Last().TournamentId);
        }

        [Fact]

        public async Task GetAllCurrentTeamTournaments()
        {
            List<TournamentDTO> tournaments = await _teamService.GetOngoingTournaments(TEAMID);

            Assert.NotNull(tournaments);
            Assert.Equal(0, tournaments?.Count??0);
        }

        [Fact]

        public async Task GetAllPastTeamTournaments()
        {
            List<TournamentDTO> tournaments = await _teamService.GetPastTournaments(TEAMID);

            Assert.NotNull(tournaments);
            Assert.Equal(4, tournaments?.Count ?? 0);
            Assert.Equal("Paris, France", tournaments.Last().TournamentLocation);
        }
    }
}
