using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class MatchConfig : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("matches");
        builder.HasKey(x => x.MatchId);

        builder.Property(x => x.TimeSpanInMinutes).HasPrecision(15, 2);

        builder.HasOne(x => x.Tournament)
            .WithMany(x => x.Matches)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(x => x.TournamentId);

        //builder.HasMany(x => x.Rounds)
        //    .WithOne(x => x.Match)
        //    .OnDelete(DeleteBehavior.NoAction)
        //    .HasForeignKey(x => x.RoundId);
    }
}
