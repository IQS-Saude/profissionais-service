namespace ProfissionaisService.application.Ports;

public interface IBuscarTratamentosPorProfissionalIdQueryService
{
    public Task<List<string>?> BuscarTratamentosPorProfissionalId(int profissionalId);
}