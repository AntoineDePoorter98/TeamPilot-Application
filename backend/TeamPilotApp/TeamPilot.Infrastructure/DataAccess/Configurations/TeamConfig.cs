using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class TeamConfig : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("teams");
        builder.HasKey(x => x.TeamId);

        builder.Property(x => x.TeamName).HasMaxLength(50);
        builder.Property(x => x.AvatarUrl).HasMaxLength(150);

        builder.HasOne(x => x.TeamManager)
            .WithMany(x => x.Teams)
            .OnDelete(DeleteBehavior.NoAction);

        //builder.HasMany(x => x.Matches)
        //.WithMany(x => x.Teams)
        //.UsingEntity("teams_matches");

        //builder.HasMany(x => x.Tournaments)
        //    .WithMany(x => x.Teams)
        //    .UsingEntity("tournaments_teams");
    }
}
