using TeamPilot.Application.Dtos.Feed;
using TeamPilot.Application.Exceptions;
using TeamPilot.Application.ExtensionMethods;
using TeamPilot.Application.Interfaces.Repositories;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Application.Services;

public class ArticleService
{
    private CurrentUserService _currentUserService;
    private IArticleRepository _articleRepository;
    private User _currentUser;
    public ArticleService(IArticleRepository articleRepository, CurrentUserService currentUserService)
    {
        _articleRepository = articleRepository;
        _currentUserService = currentUserService;
        _currentUser = _currentUserService.CurrentUser;
    }

    public async Task<List<ArticleDTO>> GetAllArticlesAsync()
    {
        var toReturn = await _articleRepository.GetAllAsync();
        return toReturn.ToDTOs();
    }

    public async Task<ArticleDTO> GetArticleByIdAsync(string id)
    {
        Article article = await _articleRepository.FirstOrDefaultAsync(x => x.ArticleId.ToString() == id);
        if (IsNull(article))
            throw new UnknownResourceException("article doesnt exist");
        return article!.ToDTO();
    }

    public async Task PostArticleAsync(ArticleDTO dto)
    {
        ValidateNewPost(dto);
        await _articleRepository.InsertAsync(dto.ToEntity());
    }

    public async Task EditArticleAsync(string id, ArticleDTO dto)
    {
        var toEdit = await _articleRepository.FirstOrDefaultAsync(x => x.ArticleId.ToString() == id);
        if (toEdit != null)
        {
            toEdit.AuthorName = dto.AuthorName;
            toEdit.PicUrl = dto.PicUrl;
            toEdit.VidUrl = dto.VidUrl;
            toEdit.Title = dto.Title;
            toEdit.Body = dto.Body;
            if (dto.TournamentId != null)
                toEdit.TournamentId = new Guid(dto.TournamentId);
            if (dto.PlayerId != null)
                toEdit.PlayerId = new Guid(dto.PlayerId);
            if (dto.TeamId != null)
                toEdit.TeamId = new Guid(dto.TeamId);
            toEdit.CreationDate = toEdit.CreationDate;

            await _articleRepository.UpdateAsync(toEdit);
        }
    }

    public async Task DeleteArticleAsync(string id)
    {
        var toDelete = await _articleRepository.FirstOrDefaultAsync(x => x.ArticleId.ToString() == id);
        if (toDelete == null)
            throw new UnknownResourceException();
        await _articleRepository.DeleteAsync(toDelete);
    }

    public async Task<List<ArticleDTO>> GetArticlesForFollowingAsync()
    {
        if (_currentUser is RegisteredUser)
        {
            var articles = await _articleRepository.GetAllArticlesForFollowingAsync(_currentUser.UserId);
            return articles.ToDTOs();
        }
        else
        {
            throw new NoAccessException("This method is only accessible for registered users");
        }
    }


    // Validation
    private bool IsNull(object obj)
    {
        if (obj == null)
            return true;
        return false;
    }

    private void ValidateNewPost(ArticleDTO dto)
    {
        DateTime minDate = DateTime.Now.AddDays(-1);
        DateTime maxDate = DateTime.Now.AddMinutes(10);


        if (dto.ArticleId != null)
            throw new IllegalFieldFoundException("Id for a new article must be empty");    
        if (dto.Title == "" || dto.Title == null)
            throw new IllegalFieldFoundException("Title field is empty");
        if (dto.CreationDate < minDate || dto.CreationDate > maxDate)
            throw new IllegalFieldFoundException("Your date is not valid");
        if (dto.Body == "" || dto.Body == null)
            throw new IllegalFieldFoundException("Your body field is empty");
        if (dto.PlayerId == null && dto.TeamId == null && dto.TournamentId == null)
            throw new IllegalFieldFoundException("The article needs to be coupled to a player, team or tournament");
    }
}
