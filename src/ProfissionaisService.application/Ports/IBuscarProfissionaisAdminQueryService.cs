using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Ports;

public interface IBuscarProfissionaisAdminQueryService
{
    public Task<ProfissionalAdmin[]> BuscarProfissionaisPorStatus(bool status, int pagina, int limite);

    public Task<int> ContarProfissionaisPorStatus(bool status);
}