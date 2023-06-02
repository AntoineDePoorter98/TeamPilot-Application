using TeamPilot.Application.Dtos.Feed;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.ExtensionMethods;

public static class ArticleDTOExtensions
{
    public static Article ToEntity(this ArticleDTO dto)
    {
        Article entity = new()
        {
            ArticleId = dto.ArticleId == null ? Guid.NewGuid() : new Guid(dto.ArticleId),
            AuthorName = dto.AuthorName,
            Body = dto.Body,
            CreationDate = dto.CreationDate,
            PicUrl = dto.PicUrl,
            VidUrl = dto.VidUrl,
            Title = dto.Title,
            TeamId = dto.TeamId == null ? null : new Guid(dto.TeamId),
            PlayerId = dto.PlayerId == null ? null : new Guid(dto.PlayerId),
            TournamentId = dto.TournamentId == null ? null : new Guid(dto.TournamentId)
        };
        return entity;
    }

    public static List<Article> ToEntities(this List<ArticleDTO> dtos)
    {
        List<Article> entities = new();
        foreach (ArticleDTO dto in dtos)
        {
            var entity = dto.ToEntity();
            entities.Add(entity);
        }
        return entities;
    }
}
