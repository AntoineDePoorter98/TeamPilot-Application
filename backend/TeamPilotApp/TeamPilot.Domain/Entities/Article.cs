namespace TeamPilot.Domain.Entities;

public class Article
{
    public Guid ArticleId { get; set; }
    public string Title { get; set; }
    public string? AuthorName { get; set; }
    public string Body { get; set; }
    public string? PicUrl { get; set; }
    public string? VidUrl { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid? TeamId { get; set; }
    public Guid? PlayerId { get; set; }
    public Guid? TournamentId { get; set; }
}
