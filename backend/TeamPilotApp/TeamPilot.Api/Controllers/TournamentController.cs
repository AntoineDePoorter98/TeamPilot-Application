using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.Tournament;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Controllers;

[ApiController]
[Route("tournaments")]
public class TournamentController : ControllerBase
{
    private readonly TournamentService _tournamentService;

    public TournamentController(TournamentService tournamentService)
    {
        _tournamentService = tournamentService;
    }

    [HttpPost("")]
    public async Task CreateTournamentAsync([FromBody] NewTournamentDTO newTournamentDTO)
    {
        await _tournamentService.CreateANewTournament(newTournamentDTO);
    }

    [HttpGet]
    public async Task<List<TournamentDTO>> GetTournamentsAsync()
    {
        return await _tournamentService.GetAllTournaments();
    }

    [HttpGet("teams")]
    public async Task<List<TeamForTournamentDTO>> GetTeamsForTournaments()
    {
        return await _tournamentService.GetTeamsToSelectForTournament();
    }

    [HttpGet("{id}")]
    public async Task<TournamentDTO> GetTournamentByIdAsync([FromRoute] string id)
    {
        return await _tournamentService.GetTournamentByID(id);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task DeleteTournamentAsync([FromRoute] string id)
    {
        await _tournamentService.DeleteAnExistingTournament(id);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task EditTournamentAsync([FromBody] NewTournamentDTO newTournamentDTO)
    {
        await _tournamentService.UpdateAnExistingTournament(newTournamentDTO);
    }

    [HttpGet("tournamentmanager/{id}")]
    public async Task<List<TournamentForManagerDTO>> GetTournamentsForManagerAsync([FromRoute] string id)
    {
        return await _tournamentService.GetAllTournamentsForManager(id);
    }
}