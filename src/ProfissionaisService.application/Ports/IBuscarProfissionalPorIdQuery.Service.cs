using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Ports;

public interface IBuscarProfissionalPorIdQueryService
{
    public Task<BuscarProfissionalPorIdResponse?> BuscarProfissionalPorId(int id);
}