using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.Midias;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class VideoEntityTypeConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasBaseType(typeof(MidiaAbstract));

        builder.Property(e => e.UrlThumbnail).IsRequired();
    }
}