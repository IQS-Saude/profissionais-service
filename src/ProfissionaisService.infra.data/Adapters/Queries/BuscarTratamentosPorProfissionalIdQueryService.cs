using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarTratamentosPorProfissionalIdQueryService : IBuscarTratamentosPorProfissionalIdQueryService
{
    private readonly ProfissionalContext _profissionalContext;

    public BuscarTratamentosPorProfissionalIdQueryService(ProfissionalContext profissionalContext)
    {
        _profissionalContext = profissionalContext;
    }

    public async Task<List<string>?> BuscarTratamentosPorProfissionalId(int profissionalId)
    {
        return await _profissionalContext.Profissionais.Where(profissional => profissional.Id == profissionalId)
            .Select(profissional => profissional.Tratamentos.Select(tratamento => tratamento.Descricao).ToList())
            .FirstOrDefaultAsync();
    }
}