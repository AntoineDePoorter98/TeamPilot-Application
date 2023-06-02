using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Dtos.UserDtos;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Extensions
{
    public static class UserHelper
    {
        public static UserWithNullablePlayerPropsDTO MapUserEntityToUserDto(this Player user)
        {
            var dto = new UserWithNullablePlayerPropsDTO { AvatarUrl = user.AvatarUrl, Bio = user.Bio, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Nickname = user.Nickname, UserId = user.UserId.ToString(), MonthlySalary = user.MonthlySalary, TeamId = user.TeamId.ToString(), UserType = "Player" };

            return dto;
        }
        public static UserWithNullablePlayerPropsDTO MapUserEntityToUserDto(this TeamManager user)
        {
            var dto = new UserWithNullablePlayerPropsDTO { AvatarUrl = user.AvatarUrl, Bio = user.Bio, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Nickname = user.Nickname, UserId = user.UserId.ToString(), UserType = "TeamManager" };

            return dto;
        }
        public static UserWithNullablePlayerPropsDTO MapUserEntityToUserDto(this TournamentManager user)
        {
            var dto = new UserWithNullablePlayerPropsDTO { AvatarUrl = user.AvatarUrl, Bio = user.Bio, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Nickname = user.Nickname, UserId = user.UserId.ToString(), UserType = "TournamentManager" };

            return dto;
        }
        public static UserWithNullablePlayerPropsDTO MapUserEntityToUserDto(this RegisteredUser user)
        {
            var dto = new UserWithNullablePlayerPropsDTO { AvatarUrl = user.AvatarUrl, Bio = user.Bio, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Nickname = user.Nickname, UserId = user.UserId.ToString(), UserType = "RegisteredUser" };

            return dto;
        }
        public static List<TournamentMatchDTO> MapToDto(this List<(Tournament tournament, Match match)> data)
        {
            var dto = new List<TournamentMatchDTO>();

            // Today's date
            DateTime today = DateTime.Today;

            foreach (var (tournament, match) in data)
            {
                if (tournament.EndDate < today || match.Date < today)
                {
                    // Skip this iteration if the tournament or match has already ended
                    continue;
                }

                var participatingTeams = match.Teams.Select(t => new TeamForTournamentDTO
                {
                    TeamId = t.TeamId.ToString(),
                    TeamName = t.TeamName,
                    AvatarURL = t.AvatarUrl
                }).ToList();

                dto.Add(new TournamentMatchDTO
                {
                    Tournament = new TournamentDTO
                    {
                        TournamentId = tournament.TournamentId.ToString(),
                        TournamentName = tournament.Title,
                        TournamentFormat = tournament.TournamentFormat,
                        TournamentPrizePool = tournament.PrizeMoney,
                        TournamentStartDate = tournament.StartDate,
                        TournamentEndDate = tournament.EndDate
                    },
                    Match = new MatchDTO
                    {
                        MatchId = match.MatchId.ToString(),
                        MatchLengthInMinutes = match.TimeSpanInMinutes.ToString(),
                        MatchDate = match.Date.ToString("yyyy-MM-dd"),
                        ParticipatingTeams = participatingTeams
                    }
                });
            }

            // Order matches by date ascending (soonest first)
            dto = dto.OrderBy(d => DateTime.Parse(d.Match.MatchDate)).ToList();

            return dto;
        }


    }
}
