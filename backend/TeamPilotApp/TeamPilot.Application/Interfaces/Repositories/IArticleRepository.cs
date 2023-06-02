using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Interfaces.Repositories;

public interface IArticleRepository : IRepository<Article>
{
    Task<List<Article>> GetAllArticlesForFollowingAsync(Guid userId);
}
