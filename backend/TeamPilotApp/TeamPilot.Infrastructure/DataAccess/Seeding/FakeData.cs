using Bogus;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess.Seeding.Models;

namespace TeamPilot.Infrastructure.DataAccess.Seeding
{
    public static class FakeData
    {
        private static Faker<Match> _matchFaker = new();
        private static Faker<RegisteredUser> _registeredUserFaker = new();
        private static Faker<Round> _roundFaker = new();
        private static Faker<RoundEvent> _roundEventFaker = new();

        //Many2Many
        private static Faker<RegisteredUsersFollowedTournament> _registeredUsersFollowedTournamentsFaker = new();
        private static Faker<RegisteredUsersFollowedPlayers> _registeredUsersFollowedPlayersFaker = new();
        private static Faker<RegisteredUsersFollowedTeams> _registeredUsersFollowedTeamsFaker = new();
        private static Faker<TeamMatches> _teamMatchesFaker = new();
        private static Faker<TournamentTeams> _tournamentTeamsFaker = new();

        public static List<Article> Articles = new();
        public static List<Match> Matches = new();
        public static List<Player> Players = new();
        public static List<RegisteredUser> RegisteredUsers = new();
        public static List<Round> Rounds = new();
        public static List<RoundEvent> RoundEvents = new();
        public static List<Team> Teams = new();
        public static List<TeamManager> TeamManagers = new();
        public static List<Tournament> Tournaments = new();
        public static List<TournamentManager> TournamentManagers = new();

        //Many2Many
        public static List<RegisteredUsersFollowedTournament> RegisteredUsersFollowedTournaments = new();
        public static List<RegisteredUsersFollowedPlayers> RegisteredUsersFollowedPlayers = new();
        public static List<RegisteredUsersFollowedTeams> RegisteredUsersFollowedTeams = new();
        public static List<TeamMatches> TeamMatches = new();
        public static List<TournamentTeams> TournamentTeams = new();

        public static void Init()
        {
            //Data Lists
            Lists listsOfRealFakeData = RealFakeData.GetRealFakeData();

            TeamManagers = listsOfRealFakeData.TeamManagers;
      
            Teams = listsOfRealFakeData.Teams;

            Players = listsOfRealFakeData.Players;

            TournamentManagers = listsOfRealFakeData.TournamentManagers;

            Tournaments = listsOfRealFakeData.Tournaments;

            Articles = listsOfRealFakeData.Articles;

            _matchFaker = new Faker<Match>()
                .UseSeed(17)
                .RuleFor(x => x.MatchId, f => Guid.NewGuid())
                .RuleFor(x => x.TournamentId, f => f.PickRandom(Tournaments).TournamentId)
                .RuleFor(x => x.Date, (f, match) =>
                {
                    var tournament = Tournaments.FirstOrDefault(x => x.TournamentId == match.TournamentId);
                    var tournamentDate = f.Date.Between(tournament.StartDate, tournament.EndDate);
                    return tournamentDate;
                })
                .RuleFor(x => x.TimeSpanInMinutes, f => f.Random.Double(35D, 65D));
            Matches = _matchFaker.Generate(100);

            _registeredUserFaker = new Faker<RegisteredUser>()
                .UseSeed(11)
                .RuleFor(d => d.UserId, f => Guid.NewGuid())
                .RuleFor(d => d.Nickname, f => f.Internet.UserName())
                .RuleFor(d => d.AvatarUrl, f => f.Internet.Avatar())
                .RuleFor(d => d.FirstName, f => f.Name.FirstName())
                .RuleFor(d => d.LastName, f => f.Name.LastName())
                .RuleFor(d => d.Email, f => f.Internet.Email())
                .RuleFor(d => d.Bio, f => f.Lorem.Sentence(1));
            RegisteredUsers = _registeredUserFaker.Generate(10);

            _registeredUsersFollowedTournamentsFaker = new Faker<RegisteredUsersFollowedTournament>()
                .UseSeed(20)
                .RuleFor(x => x.RegisteredUserId, f => f.PickRandom(RegisteredUsers).UserId)
                .RuleFor(x => x.TournamentId, f => f.PickRandom(Tournaments).TournamentId);
            RegisteredUsersFollowedTournaments = new HashSet<RegisteredUsersFollowedTournament>(_registeredUsersFollowedTournamentsFaker.Generate(100)).ToList();

            _registeredUsersFollowedPlayersFaker = new Faker<RegisteredUsersFollowedPlayers>()
                .UseSeed(21)
                .RuleFor(x => x.RegisteredUserId, f => f.PickRandom(RegisteredUsers).UserId)
                .RuleFor(x => x.PlayerId, f => f.PickRandom(Players).UserId);
            RegisteredUsersFollowedPlayers = new HashSet<RegisteredUsersFollowedPlayers>(_registeredUsersFollowedPlayersFaker.Generate(100)).ToList();

            _registeredUsersFollowedTeamsFaker = new Faker<RegisteredUsersFollowedTeams>()
                .UseSeed(22)
                .RuleFor(x => x.RegisteredUserId, f => f.PickRandom(RegisteredUsers).UserId)
                .RuleFor(x => x.TeamId, f => f.PickRandom(Teams).TeamId);
            RegisteredUsersFollowedTeams = new HashSet<RegisteredUsersFollowedTeams>(_registeredUsersFollowedTeamsFaker.Generate(100)).ToList();

            _teamMatchesFaker = new Faker<TeamMatches>()
                .UseSeed(23)
                .RuleFor(x => x.TeamId, f => f.PickRandom(Teams).TeamId)
                .RuleFor(x => x.MatchId, f => f.PickRandom(Matches).MatchId);
            TeamMatches = FilterTeamMatches(new HashSet<TeamMatches>(_teamMatchesFaker.Generate(1000)).ToList());

            _tournamentTeamsFaker = new Faker<TournamentTeams>()
                .UseSeed(24)
                .RuleFor(x => x.TournamentId, f => f.PickRandom(Tournaments).TournamentId)
                .RuleFor(x => x.TeamId, f => f.PickRandom(Teams).TeamId);
            TournamentTeams = FilterTournamentTeams(new HashSet<TournamentTeams>(_tournamentTeamsFaker.Generate(500)).ToList());

            _roundFaker = new Faker<Round>()
               .UseSeed(18)
               .RuleFor(x => x.RoundId, f => Guid.NewGuid())
               .RuleFor(x => x.RoundCounter, f => f.Random.Number(1, 30))
               .RuleFor(x => x.MatchId, f => f.PickRandom(Matches).MatchId)
               .RuleFor(x => x.PlayerMVPId, (f, round) =>
               {
                   var teamsofCurrentMatch = TeamMatches
                                               .Where(teamMatch => teamMatch.MatchId == round.MatchId)
                                               .Select(teamMatch => Teams.FirstOrDefault(team => team.TeamId == teamMatch.TeamId))
                                               .ToList();

                   var playersOfCurrentMatch = Players.Where(x => teamsofCurrentMatch.Any(team => team?.TeamId == x.TeamId));

                   return f.PickRandom(playersOfCurrentMatch).UserId;
               })
               .RuleFor(x => x.TeamWinnerId, (f, round) =>
               {
                   var teamsofCurrentMatch = TeamMatches
                                               .Where(teamMatch => teamMatch.MatchId == round.MatchId)
                                               .Select(teamMatch => Teams.FirstOrDefault(team => team.TeamId == teamMatch.TeamId))
                                               .ToList();
                   return f.PickRandom(teamsofCurrentMatch).TeamId;
               });

            Rounds = _roundFaker.Generate(1000);

            _roundEventFaker = new Faker<RoundEvent>()
                .UseSeed(19)
                .RuleFor(x => x.RoundEventId, f => Guid.NewGuid())
                .RuleFor(x => x.RoundId, f => f.PickRandom(Rounds).RoundId)
                .RuleFor(x => x.TimeStamp, (f, roundevent) =>
                {
                    var round = Rounds.FirstOrDefault(x => x.RoundId == roundevent.RoundId);
                    var match = Matches.FirstOrDefault(x => x.MatchId == round?.MatchId);
                    return f.Date.Between(match.Date, match.Date.AddMinutes(match.TimeSpanInMinutes));
                })

                .RuleFor(x => x.KillingPlayerId, (f, roundevent) =>
                {
                    var round = Rounds.FirstOrDefault(x => x.RoundId == roundevent.RoundId);
                    var teamsofCurrentMatch = TeamMatches
                                               .Where(teamMatch => teamMatch.MatchId == round?.MatchId)
                                               .Select(teamMatch => Teams.FirstOrDefault(team => team.TeamId == teamMatch.TeamId))
                                               .ToList();

                    var playersOfCurrentMatch = Players.Where(x => teamsofCurrentMatch.Any(team => team?.TeamId == x.TeamId));

                    return f.PickRandom(playersOfCurrentMatch).UserId;
                })
                .RuleFor(x => x.KilledPlayerId, (f, roundevent) =>
                {
                    var round = Rounds.FirstOrDefault(x => x.RoundId == roundevent.RoundId);
                    var teamsofCurrentMatch = TeamMatches
                                               .Where(teamMatch => teamMatch.MatchId == round?.MatchId)
                                               .Select(teamMatch => Teams.FirstOrDefault(team => team.TeamId == teamMatch.TeamId))
                                               .ToList();

                    var playersOfCurrentMatch = Players.Where(x => teamsofCurrentMatch.Any(team => team?.TeamId == x.TeamId));

                    return f.PickRandom(playersOfCurrentMatch).UserId;
                });

            RoundEvents = _roundEventFaker.Generate(2000);



            //Set WinningTeam in a Match
            foreach (var match in Matches)
            {
                var teamsInMatch = TeamMatches.Where(x => x.MatchId == match.MatchId).ToList();

                var team1 = teamsInMatch[0];
                var team2 = teamsInMatch[1];

                var team1WonRoundsInMatch = match.Rounds.Where(x => x.TeamWinnerId == team1.TeamId).Count();
                var team1LostRoundsInMatch = match.Rounds.Where(x => x.TeamWinnerId != team1.TeamId).Count();
                var team2WonRoundsInMatch = match.Rounds.Where(x => x.TeamWinnerId == team2.TeamId).Count();
                var team2LostRoundsInMatch = match.Rounds.Where(x => x.TeamWinnerId != team2.TeamId).Count();


                if (team1WonRoundsInMatch >= team2WonRoundsInMatch)
                {
                    match.WinningTeamId = team1.TeamId;
                }
                else
                {
                    match.WinningTeamId = team2.TeamId;
                }
            }
        }

        private static List<TeamMatches> FilterTeamMatches(List<TeamMatches> teamMatches)
        {
            // Filter list so a match contain min 2 and max 2 teams
            var filteredTeamMatches = new List<TeamMatches>();

            foreach (var item in teamMatches)
            {
                var teamsForCurrentMatch = teamMatches.Where(x => x.MatchId == item.MatchId).ToList();

                if (teamsForCurrentMatch.Select(x => x.TeamId).Count() > 2 && !filteredTeamMatches.Select(x => x.MatchId).Contains(item.MatchId))
                {
                    filteredTeamMatches.AddRange(teamsForCurrentMatch.Take(2));
                }
            }

            return filteredTeamMatches;
        }


        private static List<TournamentTeams> FilterTournamentTeams(List<TournamentTeams> tournamentTeams)
        {
            // A tournament has max 32 teams, and never less than 8
            var filteredTournamentTeams = new List<TournamentTeams>();

            foreach (var item in tournamentTeams)
            {
                var teamsForCurrentTournament = tournamentTeams.Where(x => x.TournamentId == item.TournamentId).ToList();

                if (teamsForCurrentTournament.Select(x => x.TeamId).Count() >= 8 && !filteredTournamentTeams.Select(x => x.TournamentId).Contains(item.TournamentId))
                {
                    //TODO:Limit teamsForCurrentTournament to be even
                    filteredTournamentTeams.AddRange(teamsForCurrentTournament.Take(32));
                }
            }

            return filteredTournamentTeams;
        }
    }
}
