using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Ports;

public interface IBuscarProfissionalPorUrlAmigavelQueryService
{
    public Task<BuscarProfissionalPorUrlAmigavelResponse?> BuscarProfissionalPorUrlAmigavel(string urlAmigavel);
}