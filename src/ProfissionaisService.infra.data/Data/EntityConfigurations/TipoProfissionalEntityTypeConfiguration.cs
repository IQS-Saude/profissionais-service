using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.TipoProfissional;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class TipoProfissionalEntityTypeConfiguration : IEntityTypeConfiguration<TipoProfissional>
{
    public void Configure(EntityTypeBuilder<TipoProfissional> builder)
    {
        builder.ToTable("tipos_profissional");

        builder.HasKey(e => e.Id);

        builder.Ignore(e => e.DomainEvents);

        builder.Property(e => e.Descricao).IsRequired();

        builder.HasMany(e => e.Especialidades)
            .WithOne()
            .HasForeignKey("tipoProfissionalId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}