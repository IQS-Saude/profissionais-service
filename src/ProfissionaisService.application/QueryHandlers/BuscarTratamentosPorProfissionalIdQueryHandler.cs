using MediatR;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.QueryHandlers;

public class
    BuscarTratamentosPorProfissionalIdQueryHandler : IRequestHandler<BuscarTratamentosPorProfissionalIdQuery,
        List<string>>
{
    private readonly IBuscarTratamentosPorProfissionalIdQueryService _buscarTratamentosPorProfissionalIdQueryService;

    public BuscarTratamentosPorProfissionalIdQueryHandler(
        IBuscarTratamentosPorProfissionalIdQueryService buscarTratamentosPorProfissionalIdQueryService)
    {
        _buscarTratamentosPorProfissionalIdQueryService = buscarTratamentosPorProfissionalIdQueryService;
    }

    public async Task<List<string>> Handle(BuscarTratamentosPorProfissionalIdQuery request,
        CancellationToken cancellationToken)
    {
        var tratamentos =
            await _buscarTratamentosPorProfissionalIdQueryService.BuscarTratamentosPorProfissionalId(
                request.ProfissionalId);

        if (tratamentos is null) throw new ProfissionalNaoEncontradoException();

        return tratamentos;
    }
}