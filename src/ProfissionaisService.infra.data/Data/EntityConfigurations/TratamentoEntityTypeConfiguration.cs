using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfissionaisService.domain.Aggregates.Profissional;

namespace ProfissionaisService.infra.data.Data.EntityConfigurations;

public class TratamentoEntityTypeConfiguration : IEntityTypeConfiguration<Tratamento>
{
    public void Configure(EntityTypeBuilder<Tratamento> builder)
    {
        builder.ToTable("tratamentos");

        builder.Property(e => e.Descricao).IsRequired();
    }
}