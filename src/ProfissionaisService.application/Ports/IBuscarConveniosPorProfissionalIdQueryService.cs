namespace ProfissionaisService.application.Ports;

public interface IBuscarConveniosPorProfissionalIdQueryService
{
    public Task<List<string>?> BuscarConveniosPorProfissionalId(int profissionalId);
}