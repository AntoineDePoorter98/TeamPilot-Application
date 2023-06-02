using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Seeding;

public class Lists
{
    public List<Team> Teams { get; set; }
    public List<Player> Players { get; set; }
    public List<TeamManager> TeamManagers { get; set; }
    public List<TournamentManager> TournamentManagers { get; set; }
    public List<Tournament> Tournaments { get; set; }
    public List<Article> Articles { get; set; }
}
