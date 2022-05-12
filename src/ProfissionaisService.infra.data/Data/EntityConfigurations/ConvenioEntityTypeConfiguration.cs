using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.Profissional;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class ConvenioEntityTypeConfiguration : IEntityTypeConfiguration<Convenio>
{
    public void Configure(EntityTypeBuilder<Convenio> builder)
    {
        builder.ToTable("convenios");

        builder.Property(e => e.Descricao).IsRequired();
    }
}