using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Aggregates.TipoProfissional;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Repositories;

public class ProfissionalRepository : IProfissionalRepository
{
    public ProfissionalRepository(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<domain.Aggregates.Profissional.Profissional> Criar(
        domain.Aggregates.Profissional.Profissional profissional)
    {
        ProfissionalContext.Profissionais.Add(profissional);
        await ProfissionalContext.SaveChangesAsync();

        return profissional;
    }

    public async Task<domain.Aggregates.Profissional.Profissional> Alterar(
        domain.Aggregates.Profissional.Profissional profissional)
    {
        ProfissionalContext.Profissionais.Update(profissional);
        await ProfissionalContext.SaveChangesAsync();

        return profissional;
    }

    public async Task Remover(domain.Aggregates.Profissional.Profissional profissional)
    {
        // var model = ProfissionalMapper.ToModel(profissional);

        // ProfissionalContext.Profissionais.Remove(model);
        await ProfissionalContext.SaveChangesAsync();
    }

    public async Task<domain.Aggregates.Profissional.Profissional?> BuscarPorId(int id)
    {
        var profissional =
            await ProfissionalContext.Profissionais.Include(p => p.Especialidades)
                .FirstOrDefaultAsync(profissional => profissional.Id == id);

        return profissional;
    }

    public async Task<TipoProfissional?> BuscarTipoProfissionalPorId(int id)
    {
        var tipoProfissional =
            await ProfissionalContext.TiposProfissional.Include(tp => tp.Especialidades).FirstOrDefaultAsync(
                tipoProfissional =>
                    tipoProfissional.Id == id);

        return tipoProfissional;
    }

    public async Task<Especialidade?> BuscarEspecialidadePorId(int id)
    {
        var especialidade =
            await ProfissionalContext.Especialidades.FirstOrDefaultAsync(especialidade => especialidade.Id == id);

        return especialidade;
    }
}