using MediatR;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;

namespace ProfissionaisService.application.QueryHandlers;

public class
    BuscarTiposProfissionalQueryHandler : IRequestHandler<BuscarTiposProfissionalQuery,
        List<BuscarTiposProfissionalResponse>>
{
    public BuscarTiposProfissionalQueryHandler(IBuscarTiposProfissionalQueryService buscarTiposProfissionalQueryService)
    {
        BuscarTiposProfissionalQueryService = buscarTiposProfissionalQueryService;
    }

    private IBuscarTiposProfissionalQueryService BuscarTiposProfissionalQueryService { get; }

    public async Task<List<BuscarTiposProfissionalResponse>> Handle(BuscarTiposProfissionalQuery request,
        CancellationToken cancellationToken)
    {
        return await BuscarTiposProfissionalQueryService.BuscarTiposProfissional();
    }
}