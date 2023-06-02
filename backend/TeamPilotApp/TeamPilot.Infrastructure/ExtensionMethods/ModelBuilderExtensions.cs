using Microsoft.EntityFrameworkCore;
using TeamPilot.Domain.Entities;
using TeamPilot.Infrastructure.DataAccess.Seeding;

namespace TeamPilot.Infrastructure.ExtensionMethods
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //Seed Data
            FakeData.Init();

            modelBuilder.Entity<RegisteredUser>().HasData(FakeData.RegisteredUsers);
            modelBuilder.Entity<Team>().HasData(FakeData.Teams);
            modelBuilder.Entity<TeamManager>().HasData(FakeData.TeamManagers);
            modelBuilder.Entity<Player>().HasData(FakeData.Players);
            modelBuilder.Entity<TournamentManager>().HasData(FakeData.TournamentManagers);
            modelBuilder.Entity<Tournament>().HasData(FakeData.Tournaments);
            modelBuilder.Entity<Article>().HasData(FakeData.Articles);
            modelBuilder.Entity<Match>().HasData(FakeData.Matches);

            modelBuilder.Entity<RegisteredUser>()
               .HasMany(a => a.FollowedTournaments)
               .WithMany(b => b.Followers)
               .UsingEntity<Dictionary<string, object>>(
                   "registered_users_followed_tournaments",
                   b => b.HasOne<Tournament>().WithMany().HasForeignKey("TournamentId"),
                   b => b.HasOne<RegisteredUser>().WithMany().HasForeignKey("RegisteredUserId")
               )
               .HasData(FakeData.RegisteredUsersFollowedTournaments);

            modelBuilder.Entity<RegisteredUser>()
               .HasMany(a => a.FollowedPlayers)
               .WithMany(b => b.Followers)
               .UsingEntity<Dictionary<string, object>>(
                   "registered_users_followed_players",
                   b => b.HasOne<Player>().WithMany().HasForeignKey("PlayerId"),
                   b => b.HasOne<RegisteredUser>().WithMany().HasForeignKey("RegisteredUserId")
               )
               .HasData(FakeData.RegisteredUsersFollowedPlayers);

            modelBuilder.Entity<RegisteredUser>()
               .HasMany(a => a.FollowedTeams)
               .WithMany(b => b.Followers)
               .UsingEntity<Dictionary<string, object>>(
                   "registered_users_followed_teams",
                   b => b.HasOne<Team>().WithMany().HasForeignKey("TeamId"),
                   b => b.HasOne<RegisteredUser>().WithMany().HasForeignKey("RegisteredUserId")
               )
               .HasData(FakeData.RegisteredUsersFollowedTeams);

            modelBuilder.Entity<Team>()
                .HasMany(x => x.Matches)
                .WithMany(x => x.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "teams_matches",
                    b => b.HasOne<Match>().WithMany().HasForeignKey("MatchId"),
                    b => b.HasOne<Team>().WithMany().HasForeignKey("TeamId")
                )
                .HasData(FakeData.TeamMatches);

            modelBuilder.Entity<Team>()
                .HasMany(x => x.Tournaments)
                .WithMany(x => x.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "tournaments_teams",
                    b => b.HasOne<Tournament>().WithMany().HasForeignKey("TournamentId"),
                    b => b.HasOne<Team>().WithMany().HasForeignKey("TeamId")
                )
                .HasData(FakeData.TournamentTeams);

            //Last because Round and RoundEvent need many2many
            modelBuilder.Entity<Round>().HasData(FakeData.Rounds);
            modelBuilder.Entity<RoundEvent>().HasData(FakeData.RoundEvents);
        }
    }
}

