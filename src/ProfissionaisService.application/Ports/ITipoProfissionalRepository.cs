using ProfissionaisService.domain.Aggregates.TipoProfissional;

namespace ProfissionaisService.application.Ports;

public interface ITipoProfissionalRepository
{
    public Task<TipoProfissional?> BuscarPorId(int id);
    public Task<TipoProfissional> Salvar(TipoProfissional tipoProfissional);
}