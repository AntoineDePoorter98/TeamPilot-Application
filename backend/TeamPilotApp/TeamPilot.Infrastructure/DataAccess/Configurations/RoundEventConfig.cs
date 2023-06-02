using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class RoundEventConfig : IEntityTypeConfiguration<RoundEvent>
{
    public void Configure(EntityTypeBuilder<RoundEvent> builder)
    {
        builder.ToTable("round_events");
        builder.HasKey(x => x.RoundEventId);

        builder.HasOne(x => x.KillingPlayer)
            .WithMany(x => x.KillingPlayerRoundEvents)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.KilledPlayer)
            .WithMany(x => x.KilledPlayerRoundEvents)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
