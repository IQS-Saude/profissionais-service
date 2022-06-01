using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Ports;

public interface IBuscarProfissionaisAdminQueryService
{
    public Task<ProfissionalAdmin[]> BuscarProfissionaisPorStatus(bool status, string? nome, int pagina, int limite);

    public Task<int> ContarProfissionaisPorStatusENome(bool status, string? nome);
}