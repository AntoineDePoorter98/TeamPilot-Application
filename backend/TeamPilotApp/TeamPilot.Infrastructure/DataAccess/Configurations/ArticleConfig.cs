using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Configurations;

public class ArticleConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("articles");
        
        builder.Property(x => x.Title).HasMaxLength(150);
        builder.Property(x => x.Body).HasMaxLength(4001);
        builder.Property(x => x.AuthorName).HasMaxLength(40);
        builder.Property(x => x.PicUrl).HasMaxLength(300);
        builder.Property(x => x.VidUrl).HasMaxLength(300);
    }
}
