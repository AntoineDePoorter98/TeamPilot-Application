using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class RoundConfig : IEntityTypeConfiguration<Round>
{
    public void Configure(EntityTypeBuilder<Round> builder)
    {
        builder.ToTable("rounds");
        builder.HasKey(x => x.RoundId);

        builder.HasMany(x => x.RoundEvents)
            .WithOne(x => x.Round)
            //.HasForeignKey(x => x.RoundEventId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
