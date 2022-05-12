using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.Midias;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class PodcastEntityTypeConfiguration : IEntityTypeConfiguration<Podcast>
{
    public void Configure(EntityTypeBuilder<Podcast> builder)
    {
        builder.HasBaseType(typeof(MidiaAbstract));
    }
}