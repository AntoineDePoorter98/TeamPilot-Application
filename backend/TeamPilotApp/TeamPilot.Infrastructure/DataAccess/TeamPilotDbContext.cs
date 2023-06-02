using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess.Configurations;
using TeamPilot.Infrastructure.ExtensionMethods;

namespace TeamPilot.Infrastructure.DataAccess;

public class TeamPilotDbContext : DbContext
{
    public static IConfigurationRoot configuration = null!;
    //private string appsetting = "TeamPilotDb";

    public DbSet<User> Users { get; set; }
    public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    public DbSet<TeamManager> TeamManagers { get; set; }
    public DbSet<TournamentManager> TournamentManagers { get; set; }
    public DbSet<Player> Players { get; set; }

    public DbSet<Match> Matches { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<RoundEvent> RoundEvents { get; set; }

    public TeamPilotDbContext(DbContextOptions<TeamPilotDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --------------
        // Configurations
        // --------------
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new PlayerConfig());
        modelBuilder.ApplyConfiguration(new TournamentConfig());
        modelBuilder.ApplyConfiguration(new TeamConfig());
        modelBuilder.ApplyConfiguration(new MatchConfig());
        modelBuilder.ApplyConfiguration(new RoundConfig());
        modelBuilder.ApplyConfiguration(new RoundEventConfig());
        modelBuilder.ApplyConfiguration(new ArticleConfig());
        modelBuilder.ApplyConfiguration(new RegisteredUserConfig());

        // -------
        // Seeding
        // -------
        modelBuilder.SeedData();
    }

}
