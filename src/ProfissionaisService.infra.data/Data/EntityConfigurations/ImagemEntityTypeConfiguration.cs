using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.Midias;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class ImagemEntityTypeConfiguration : IEntityTypeConfiguration<Imagem>
{
    public void Configure(EntityTypeBuilder<Imagem> builder)
    {
        builder.HasBaseType(typeof(MidiaAbstract));
    }
}