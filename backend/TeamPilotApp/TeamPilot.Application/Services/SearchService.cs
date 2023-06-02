using TeamPilot.Application.Dtos.Search;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Services;

public class SearchService
{
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly ITournamentRepository _tournamentRepository;

    public SearchService(IUserRepository userRepository, ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
    {
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _tournamentRepository = tournamentRepository;
    }


    public async Task<List<SearchResponseDTO>> Search(string search)
    {
        var output = new List<SearchResponseDTO>();

        var players = await _userRepository.FindManyAsync(x => x.Nickname.ToLower().Contains(search.ToLower()) && x is Player);
        var teams = await _teamRepository.FindManyAsync(x => x.TeamName.ToLower().Contains(search.ToLower()));
        var tournaments = await _tournamentRepository.FindManyAsync(x => x.Title.ToLower().Contains(search.ToLower()));


        foreach (var player in players)
        {
            output.Add(new SearchResponseDTO
            {
                ResultId = player.UserId.ToString(),
                ResultType = player.GetType().Name,
                Result = player.Nickname
            });
        }
        foreach (var team in teams)
        {
            output.Add(new SearchResponseDTO
            {
                ResultId = team.TeamId.ToString(),
                ResultType = team.GetType().Name,
                Result = team.TeamName
            });
        }
        foreach (var tournament in tournaments)
        {
            output.Add(new SearchResponseDTO
            {
                ResultId = tournament.TournamentId.ToString(),
                ResultType = tournament.GetType().Name,
                Result = tournament.Title
            });
        }

        return output;
    }
}
