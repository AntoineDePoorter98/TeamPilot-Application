using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.Search;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Controllers;

[ApiController]
[Route("search")]
public class SearchController : ControllerBase
{
    private readonly SearchService _searchService;

    public SearchController(SearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<List<SearchResponseDTO>> Search([FromQuery] string search)
    {
        var list = await _searchService.Search(search);
        return list;
    }
}
