using Microsoft.AspNetCore.Mvc;
using TeamPilot.Application.Dtos.Feed;
using TeamPilot.Application.Services;

namespace TeamPilot.Api.Controllers;


[ApiController]
[Route("articles")]
public class ArticleController : ControllerBase
{
	private ArticleService _service;
    public ArticleController(ArticleService s)
    {
		_service = s;
    }

    [HttpGet]
	public async Task<List<ArticleDTO>> GetAllArticlesAsync()
	{
		return await _service.GetAllArticlesAsync();
	}

    [HttpGet("following")]
    public async Task<List<ArticleDTO>> GetAllArticlesForFollowingAsync()
    {
        return await _service.GetArticlesForFollowingAsync();
    }

    [HttpGet("{id}")]
	public async Task<ArticleDTO> GetArticleByIdAsync([FromRoute] string id) 
	{
		return await _service.GetArticleByIdAsync(id);
	}

	[HttpPost]
	public async Task PostArticle(ArticleDTO dto)
	{
		await _service.PostArticleAsync(dto);
	}

	[HttpPut("{id}")]
	public async Task EditArticle([FromRoute] string id, ArticleDTO dto)
	{
        await _service.EditArticleAsync(id, dto);
    }

    [HttpDelete("{id}")]
	public async Task DeleteArticle([FromRoute] string id)
	{
		await _service.DeleteArticleAsync(id);
    }
}
