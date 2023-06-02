namespace TeamPilot.Application.Dtos.Feed;

public class ArticleDTO
{
    public string? ArticleId { get; set; }
    public string? AuthorName { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string? PicUrl { get; set; }
    public string? VidUrl { get; set; }
    public DateTime CreationDate { get; set; }
    public string? TeamId { get; set; }
    public string? PlayerId { get; set; }
    public string? TournamentId { get; set; }
}
