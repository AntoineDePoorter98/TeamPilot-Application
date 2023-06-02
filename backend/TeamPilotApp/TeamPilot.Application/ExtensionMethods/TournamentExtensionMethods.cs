using TeamPilot.Application.Dtos.team;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.ExtensionMethods;

public class TournamentExtensionMethods
{
    #region EntityToDTOMappers

    public static List<TournamentForManagerDTO> MultipleTournamentEntitiesToManagerDTOsMapper(List<Tournament> tournaments)
    {
        List<TournamentForManagerDTO> convertedTournaments = new();
        foreach (var tournament in tournaments)
        {
            var convertedTournament = new TournamentForManagerDTO()
            {
                TournamentId = tournament.TournamentId.ToString(),
                TournamentName = tournament.Title
            };
            
            convertedTournaments.Add(convertedTournament);
        }

        return convertedTournaments;
    }

    public static TournamentDTO TournamentEntityToDTOMapper(Tournament tournament)
    {
        var convertedTournament = new TournamentDTO()
        {
            TournamentId = tournament.TournamentId.ToString(),
            TournamentName = tournament.Title,
            TournamentFormat = tournament.TournamentFormat,
            TournamentPrizePool = tournament.PrizeMoney,
            TournamentLocation = tournament.Location,
            TournamentSponsor = tournament.MainSponsorName,
            TournamentStartDate = tournament.StartDate,
            TournamentEndDate = tournament.EndDate,
            TournamentMatches = MultipleMatchEntitiesToDTOsMapper(tournament.Matches),
            TournamentParticipatingTeams = MultipleTeamEntitiesToDTOsMapper(tournament.Teams),
            WinningTeam = TeamEntityToDTOMapper(tournament.Teams.FirstOrDefault(x => x.TeamId == tournament.WinningTeamId)),
            FutureTournamentMatches = MultipleMatchEntitiesToDTOsMapper(tournament.Matches.Where(x=>x.Date >= DateTime.Today).ToList()),
            PastTournamentMatches = MultipleMatchEntitiesToPastDTOsMapper(tournament.Matches.Where(x=>x.Date < DateTime.Today).ToList()),
            UpcomingMatch = MatchEntityToDTOMapper(tournament.Matches.Where(x=>x.Date >= DateTime.Today).FirstOrDefault())
        };
        
        return convertedTournament;
    }

    public static List<TournamentDTO> MultipleTournamentEntitiesToDTOsMapper(List<Tournament> tournaments)
    {
        List<TournamentDTO> convertedTournaments = new();

        foreach (var tournament in tournaments)
        {
            var convertedTournament = TournamentEntityToDTOMapper(tournament);
            convertedTournaments.Add(convertedTournament);
        }

        return convertedTournaments;
    }

    public static TeamForTournamentDTO? TeamEntityToDTOMapper(Team? team)
    {
        if (team == null) return null;
        var convertedTeam = new TeamForTournamentDTO()
        {
            TeamId = team.TeamId.ToString(),
            TeamName = team.TeamName,
            AvatarURL = team.AvatarUrl
        };

        return convertedTeam;
    }

    public static List<TeamForTournamentDTO> MultipleTeamEntitiesToDTOsMapper(List<Team> teams)
    {
        List<TeamForTournamentDTO> convertedTeams = new();

        foreach (var team in teams)
        {
            var convertedTeam = TeamEntityToDTOMapper(team);
            convertedTeams.Add(convertedTeam);
        }

        return convertedTeams;
    }

    public static MatchDTO? MatchEntityToDTOMapper(Match? match)
    {
        if (match == null) return null;
        var convertedMatch = new MatchDTO()
        {
            MatchId = match.MatchId.ToString(),
            MatchDate = match.Date.ToString(),
            ParticipatingTeams = MultipleTeamEntitiesToDTOsMapper(match.Teams.ToList()),
            // WinningTeam = TeamEntityToDTOMapper(match.Teams.Where(x=>x.TeamId == teamId).FirstOrDefault())
        };
        //, Guid teamId
        return convertedMatch;
    }

    public static List<MatchDTO> MultipleMatchEntitiesToDTOsMapper(List<Match> matches)
    {
        List<MatchDTO> convertedMatches = new();

        foreach (var match in matches)
        {
            var convertedMatch = MatchEntityToDTOMapper(match);
            convertedMatches.Add(convertedMatch);
        }
        //, match.WinningTeamId
        return convertedMatches;
    }
    
    public static PastMatchDTO MatchEntityToPastDTOMapper(Match match)
    {
        var convertedPastMatch = new PastMatchDTO()
        {
            MatchId = match.MatchId.ToString(),
            MatchLengthInMinutes = match.TimeSpanInMinutes.ToString(),
            MatchDate = match.Date.ToString(),
            ParticipatingTeams = MultipleTeamEntitiesToDTOsMapper(match.Teams.ToList()),
            WinningTeam = TeamEntityToDTOMapper(match.Teams.Where(x=>x.TeamId == match.WinningTeamId).FirstOrDefault())
        };
        return convertedPastMatch;
    }
    
    public static List<PastMatchDTO> MultipleMatchEntitiesToPastDTOsMapper(List<Match> matches)
    {
        List<PastMatchDTO> convertedPastMatches = new();

        foreach (var match in matches)
        {
            var convertedPastMatch = MatchEntityToPastDTOMapper(match);
            convertedPastMatches.Add(convertedPastMatch);
        }
        return convertedPastMatches;
    }

    #endregion

    #region DTOToEntityMappers

    public static Tournament NewTournamentDTOToEntityMapper(NewTournamentDTO tournamentDTO, Guid tournamentManagerId)
    {
        var revertedTournament = new Tournament
        {
            /*TournamentId = new Guid(),*/
            Title = tournamentDTO.TournamentName,
            Location = tournamentDTO.TournamentLocation,
            TournamentFormat = tournamentDTO.TournamentFormat,
            MainSponsorName = tournamentDTO.TournamentSponsor,
            PrizeMoney = tournamentDTO.TournamentPrizePool,
            StartDate = DateTime.Parse(tournamentDTO.TournamentStartDate),
            EndDate = DateTime.Parse(tournamentDTO.TournamentEndDate),
            TournamentManagerId = tournamentManagerId
        };

        return revertedTournament;
    }

    #endregion
}