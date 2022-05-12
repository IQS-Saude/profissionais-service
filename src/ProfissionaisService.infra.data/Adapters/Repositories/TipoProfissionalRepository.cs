using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Aggregates.TipoProfissional;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Repositories;

public class TipoProfissionalRepository : ITipoProfissionalRepository
{
    public TipoProfissionalRepository(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<TipoProfissional?> BuscarPorId(int id)
    {
        var tipoProfissional = await ProfissionalContext.TiposProfissional.Include(tp => tp.Especialidades)
            .FirstOrDefaultAsync(tp => tp.Id == id);

        return tipoProfissional;
    }

    public async Task<TipoProfissional> Salvar(TipoProfissional tipoProfissional)
    {
        ProfissionalContext.Update(tipoProfissional);
        await ProfissionalContext.SaveChangesAsync();

        return tipoProfissional;
    }
}