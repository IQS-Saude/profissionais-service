using MediatR;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;

namespace ProfissionaisService.application.QueryHandlers;

public class
    BuscarProfissionaisAdminQueryHandler : IRequestHandler<BuscarProfissionaisAdminQuery,
        BuscarProfissionaisAdminResponse>
{
    private readonly IBuscarProfissionaisAdminQueryService _buscarProfissionaisAdminQueryService;

    public BuscarProfissionaisAdminQueryHandler(
        IBuscarProfissionaisAdminQueryService buscarProfissionaisAdminQueryService)
    {
        _buscarProfissionaisAdminQueryService = buscarProfissionaisAdminQueryService;
    }

    public async Task<BuscarProfissionaisAdminResponse> Handle(BuscarProfissionaisAdminQuery request,
        CancellationToken cancellationToken)
    {
        return new BuscarProfissionaisAdminResponse(
            await _buscarProfissionaisAdminQueryService.BuscarProfissionaisPorStatus(request.Status, request.Pagina,
                request.Limite), request.Pagina, request.Limite,
            await _buscarProfissionaisAdminQueryService.ContarProfissionaisPorStatus(request.Status));
    }
}