using TeamPilot.Application.Dtos.team;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.ExtensionMethods
{
    public static class TeamMapper
    {
        public static Team DTOToEntity(TeamDTO dto)
        {
            List<Player> players = new List<Player>();

            if (dto.Players != null)
            {
                foreach (var player in dto.Players)
                {
                    Player playerToAdd = PlayerMapper.DTOToEntity(player);
                    players.Add(playerToAdd);
                }
            }

            return new Team
            {
                TeamId = new Guid(dto.TeamId.ToString()),
                TeamManagerId = new Guid(dto.TeamManagerId.ToString()),
                TeamName = dto.TeamName,
                AvatarUrl = dto.AvatarUrl,
                Players = players
            };
        }
        public static TeamDTO EntityToDTO(Team team)
        {
            List<PlayerDTO> players = new List<PlayerDTO>();

            if (team.Players != null)
            {
                foreach (var player in team.Players)
                {
                    PlayerDTO playerToAdd = PlayerMapper.EntityToDTO(player);
                    players.Add(playerToAdd);
                }
            }

            return new TeamDTO
            {
                TeamId = team.TeamId.ToString(),
                TeamManagerId = team.TeamManagerId.ToString(),
                TeamName = team.TeamName,
                AvatarUrl = team.AvatarUrl,
                Players = players
            };

        }

        public static TeamMatchDTO? MatchEntityToTeamMatchDTOMapper(Match? match, Tournament tournament)
        {
            if (match == null) return null;
            List<TeamForTournamentDTO> matchTeams = new List<TeamForTournamentDTO>();
            if (match != null)
            {
            foreach (var team in match.Teams)
            {
                matchTeams.Add(TournamentExtensionMethods.TeamEntityToDTOMapper(team));
            }
            }
            var convertedMatch = new TeamMatchDTO()
            {
                MatchId = match.MatchId.ToString(),
                MatchDate = match.Date.ToString(),
                ParticipatingTeams = matchTeams,

                TournamentId = tournament.TournamentId.ToString(),
                TournamentTitle = tournament.Title
            };
            return convertedMatch;
        }
    }
}
