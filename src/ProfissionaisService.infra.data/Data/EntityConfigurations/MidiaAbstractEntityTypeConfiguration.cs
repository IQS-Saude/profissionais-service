using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.Midias;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class MidiaAbstractEntityTypeConfiguration : IEntityTypeConfiguration<MidiaAbstract>
{
    public void Configure(EntityTypeBuilder<MidiaAbstract> builder)
    {
        builder.ToTable("midias");

        builder.HasKey(e => new { e.Titulo, e.Url });

        builder.Property(e => e.Titulo).IsRequired();
        builder.Property(e => e.Url).IsRequired();
        builder.HasOne(e => e.TipoMidia)
            .WithMany()
            .HasForeignKey("_tipoMidiaId");
    }
}