using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarConveniosPorProfissionalIdQueryService : IBuscarConveniosPorProfissionalIdQueryService
{
    private readonly ProfissionalContext _profissionalContext;

    public BuscarConveniosPorProfissionalIdQueryService(ProfissionalContext profissionalContext)
    {
        _profissionalContext = profissionalContext;
    }

    public async Task<List<string>?> BuscarConveniosPorProfissionalId(int profissionalId)
    {
        return await _profissionalContext.Profissionais.Where(profissional => profissional.Id == profissionalId)
            .Select(profissional => profissional.Convenios.Select(convenio => convenio.Descricao).ToList())
            .FirstOrDefaultAsync();
    }
}