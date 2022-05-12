using Microsoft.EntityFrameworkCore;
using ProfissionaisService.domain.Aggregates.Midias;
using ProfissionaisService.domain.Aggregates.TipoProfissional;
using ProfissionaisService.infra.data.Data.EntityConfigurations;

namespace ProfissionaisService.infra.data.Data;

public class ProfissionalContext : DbContext
{
    public ProfissionalContext(DbContextOptions<ProfissionalContext> options) : base(options)
    {
    }

    public DbSet<domain.Aggregates.Profissional.Profissional> Profissionais =>
        Set<domain.Aggregates.Profissional.Profissional>();

    public DbSet<TipoProfissional> TiposProfissional => Set<TipoProfissional>();
    public DbSet<Especialidade> Especialidades => Set<Especialidade>();
    public DbSet<MidiaAbstract> Midias => Set<MidiaAbstract>();
    public DbSet<TipoMidia> TiposMidia => Set<TipoMidia>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EspecialidadeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MidiaAbstractEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TipoMidiaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ImagemEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PodcastEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new VideoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProfissionalEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TipoProfissionalEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}