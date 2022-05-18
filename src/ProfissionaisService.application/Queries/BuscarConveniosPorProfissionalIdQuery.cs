using MediatR;

namespace ProfissionaisService.application.Queries;

public class BuscarConveniosPorProfissionalIdQuery : IRequest<List<string>>
{
    public BuscarConveniosPorProfissionalIdQuery(int profissionalId)
    {
        ProfissionalId = profissionalId;
    }

    public int ProfissionalId { get; }
}