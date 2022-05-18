using MediatR;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.QueryHandlers;

public class
    BuscarConveniosPorProfissionalIdQueryHandler : IRequestHandler<BuscarConveniosPorProfissionalIdQuery, List<string>>
{
    private readonly IBuscarConveniosPorProfissionalIdQueryService _buscarConveniosPorProfissionalIdQueryService;

    public BuscarConveniosPorProfissionalIdQueryHandler(
        IBuscarConveniosPorProfissionalIdQueryService buscarConveniosPorProfissionalIdQueryService)
    {
        _buscarConveniosPorProfissionalIdQueryService = buscarConveniosPorProfissionalIdQueryService;
    }

    public async Task<List<string>> Handle(BuscarConveniosPorProfissionalIdQuery request,
        CancellationToken cancellationToken)
    {
        var convenios =
            await _buscarConveniosPorProfissionalIdQueryService
                .BuscarConveniosPorProfissionalId(request.ProfissionalId);

        if (convenios is null) throw new ProfissionalNaoEncontradoException();

        return convenios;
    }
}