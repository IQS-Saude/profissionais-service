using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class DashboardQueryService : IDashboardQueryService
{
    private readonly ProfissionalContext _profissionalContext;

    public DashboardQueryService(ProfissionalContext profissionalContext)
    {
        _profissionalContext = profissionalContext;
    }

    public async Task<DashboardResponse> BuscarDadosDashboard()
    {
        var ativos = await _profissionalContext.Profissionais.CountAsync(profissional => profissional.Status);
        var inativos = await _profissionalContext.Profissionais.CountAsync(profissional => !profissional.Status);

        return new DashboardResponse(ativos, inativos);
    }
}