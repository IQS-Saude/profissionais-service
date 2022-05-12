using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.Midias;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class TipoMidiaEntityTypeConfiguration : IEntityTypeConfiguration<TipoMidia>
{
    public void Configure(EntityTypeBuilder<TipoMidia> builder)
    {
        builder.ToTable("tipos_midia");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasDefaultValue(1)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(o => o.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}