using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarProfissionaisAdminQueryService : IBuscarProfissionaisAdminQueryService
{
    private readonly ProfissionalContext _profissionalContext;

    public BuscarProfissionaisAdminQueryService(ProfissionalContext profissionalContext)
    {
        _profissionalContext = profissionalContext;
    }

    public async Task<ProfissionalAdmin[]> BuscarProfissionaisPorStatus(bool status, int pagina, int limite)
    {
        //TODO Adicionar Visualizacoes ao Profissional
        return await _profissionalContext.Profissionais.Where(profissional => profissional.Status == status)
            .Take(limite)
            .Skip((pagina - 1) * limite).Select(profissional => new ProfissionalAdmin(profissional.Id,
                profissional.Nome, profissional.UnidadeId, 00, profissional.Recomendado, profissional.Status))
            .ToArrayAsync();
    }

    public async Task<int> ContarProfissionaisPorStatus(bool status)
    {
        return await _profissionalContext.Profissionais.CountAsync(profissional => profissional.Status == status);
    }
}