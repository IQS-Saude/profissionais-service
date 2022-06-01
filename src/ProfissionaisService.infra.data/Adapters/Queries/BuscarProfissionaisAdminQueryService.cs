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

    public async Task<ProfissionalAdmin[]> BuscarProfissionaisPorStatus(bool status, string? nome, int pagina,
        int limite)
    {
        //TODO Adicionar Visualizacoes ao Profissional
        var query = _profissionalContext.Profissionais.Where(profissional => profissional.Status == status);

        if (nome is not null) query = query.Where(profissional => profissional.Nome.Contains(nome));

        return await query.Skip((pagina - 1) * limite)
            .Take(limite).Select(profissional => new ProfissionalAdmin(profissional.Id,
                profissional.Nome, profissional.UnidadeId, 00, profissional.Recomendado, profissional.Status))
            .ToArrayAsync();
    }

    public async Task<int> ContarProfissionaisPorStatusENome(bool status, string? nome)
    {
        var queryCount = _profissionalContext.Profissionais.Where(profissional => profissional.Status == status);

        if (nome is not null) queryCount = queryCount.Where(profissional => profissional.Nome.Contains(nome));

        return await queryCount.CountAsync();
    }
}