using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class RegisteredUserConfig : IEntityTypeConfiguration<RegisteredUser>
{
    public void Configure(EntityTypeBuilder<RegisteredUser> builder)
    {

    }
}
