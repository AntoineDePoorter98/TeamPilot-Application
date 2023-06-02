using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class TournamentConfig : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.ToTable("tournaments");
        builder.HasKey(e => e.TournamentId);

        builder.Property(e => e.Title).HasMaxLength(50);
        builder.Property(e => e.Location).HasMaxLength(50);
        builder.Property(e => e.TournamentFormat).HasMaxLength(50);
        builder.Property(e => e.MainSponsorName).HasMaxLength(50);
        builder.Property(e => e.PrizeMoney).HasPrecision(15, 2);

        builder.HasOne(x => x.TournamentManager)
            .WithMany(x => x.Tournaments)
            .HasForeignKey(x => x.TournamentManagerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}
