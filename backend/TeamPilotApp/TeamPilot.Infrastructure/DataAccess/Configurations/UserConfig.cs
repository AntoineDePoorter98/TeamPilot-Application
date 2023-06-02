using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(x => x.Nickname).HasMaxLength(50);
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.FirstName).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(50);
        builder.Property(x => x.AvatarUrl).HasMaxLength(150);
        builder.Property(x => x.Bio).HasMaxLength(300);

        builder.HasDiscriminator<string>("UserType")
            .HasValue<Player>("Player")
            .HasValue<RegisteredUser>("RegisteredUser")
            .HasValue<TeamManager>("TeamManager")
            .HasValue<TournamentManager>("TournamentManager");
    }
}
