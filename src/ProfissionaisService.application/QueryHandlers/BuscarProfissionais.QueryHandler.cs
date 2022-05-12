using MediatR;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;

namespace ProfissionaisService.application.QueryHandlers;

public class BuscarProfissionaisQueryHandler : IRequestHandler<BuscarProfissionaisQuery, BuscarProfissionaisResponse>
{
    public BuscarProfissionaisQueryHandler(IBuscarProfissionaisQueryService buscarProfissionaisQueryService)
    {
        BuscarProfissionaisQueryService = buscarProfissionaisQueryService;
    }

    private IBuscarProfissionaisQueryService BuscarProfissionaisQueryService { get; }

    public async Task<BuscarProfissionaisResponse> Handle(BuscarProfissionaisQuery request,
        CancellationToken cancellationToken)
    {
        var result = await BuscarProfissionaisQueryService.BuscarProfissionais(request);

        return result;
    }
}