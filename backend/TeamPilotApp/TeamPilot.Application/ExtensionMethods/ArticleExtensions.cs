using TeamPilot.Application.Dtos.Feed;
using TeamPilot.Application.Extensions;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.ExtensionMethods;

public static class ArticleExtensions
{
    public static ArticleDTO ToDTO(this Article article)
    {
        ArticleDTO dto = new()
        {
            ArticleId = article.ArticleId.ToString(),
            AuthorName = article.AuthorName,
            Body = article.Body,
            CreationDate = article.CreationDate,
            PicUrl = article.PicUrl,
            VidUrl = article.VidUrl,
            Title = article.Title,
            PlayerId = article.PlayerId.ToString(),
            TournamentId = article.TournamentId.ToString(),
            TeamId = article.TeamId.ToString()
        };
        return dto;
    }

    public static List<ArticleDTO> ToDTOs(this List<Article> articles)
    {
        List<ArticleDTO> dtos = new();
        foreach (Article article in articles)
        {
            var dto = article.ToDTO();
            dtos.Add(dto);
        }
        return dtos;
    }
}
