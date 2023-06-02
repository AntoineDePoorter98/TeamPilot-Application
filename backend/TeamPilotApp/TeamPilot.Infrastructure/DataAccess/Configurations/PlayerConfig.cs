using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class PlayerConfig : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.Property(x => x.MonthlySalary).HasPrecision(15, 2);

        builder.HasOne(x => x.Team)
            .WithMany(x => x.Players)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
