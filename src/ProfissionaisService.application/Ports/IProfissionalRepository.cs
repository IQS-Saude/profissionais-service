using ProfissionaisService.domain.Aggregates.Profissional;
using ProfissionaisService.domain.Aggregates.TipoProfissional;

namespace ProfissionaisService.application.Ports;

public interface IProfissionalRepository
{
    public Task<Profissional> Criar(
        Profissional profissional);

    public Task<Profissional> Alterar(
        Profissional profissional);

    public Task Remover(Profissional profissional);

    public Task<Profissional?> BuscarPorId(int id);

    public Task<TipoProfissional?> BuscarTipoProfissionalPorId(int id);

    public Task<Especialidade?> BuscarEspecialidadePorId(int id);
}