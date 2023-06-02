using TeamPilot.Application.Services;

namespace TeamPilot.Tests;

public class ArticleServiceTests
{
    private readonly ArticleService _articleService;
    public ArticleServiceTests(ArticleService articleService)
    {
        _articleService = articleService;
    }

    [Fact]
    public async Task GetAllArticles()
    {
        // Arrange

        // Act
        var articles = await _articleService.GetAllArticlesAsync();

        // Assert
        Assert.Equal(10, articles.Count);
    }

    [Fact]
    public async Task GetArticleById()
    {
        // Arrange

        // Act
        var article = await _articleService.GetArticleByIdAsync("6370786f-670b-459b-be33-07661782180a");

        // Assert
        Assert.Equal("6370786f-670b-459b-be33-07661782180a", article.ArticleId);
    }
}
