using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarTiposProfissionalQueryService : IBuscarTiposProfissionalQueryService
{
    public BuscarTiposProfissionalQueryService(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<List<BuscarTiposProfissionalResponse>> BuscarTiposProfissional()
    {
        return await ProfissionalContext.TiposProfissional.Select(tipoProfissional =>
            new BuscarTiposProfissionalResponse(tipoProfissional.Id, tipoProfissional.Descricao,
                tipoProfissional.Especialidades.Select(especialidade =>
                        new BuscarTiposProfissionalEspecialidadeResponse(especialidade.Id, especialidade.Descricao))
                    .ToList())
        ).ToListAsync();
    }
}