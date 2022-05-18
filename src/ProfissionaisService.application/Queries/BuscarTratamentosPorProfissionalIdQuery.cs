using MediatR;

namespace ProfissionaisService.application.Queries;

public class BuscarTratamentosPorProfissionalIdQuery : IRequest<List<string>>
{
    public BuscarTratamentosPorProfissionalIdQuery(int profissionalId)
    {
        ProfissionalId = profissionalId;
    }

    public int ProfissionalId { get; }
}