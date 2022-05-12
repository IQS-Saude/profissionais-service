using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Ports;

public interface IBuscarTiposProfissionalQueryService
{
    Task<List<BuscarTiposProfissionalResponse>> BuscarTiposProfissional();
}