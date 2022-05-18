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
        var profissionais = await _buscarProfissionaisAdminQueryService.BuscarProfissionaisPorStatus(request.Status,
            request.Pagina,
            request.Limite);
        var totalProfissionais =
            await _buscarProfissionaisAdminQueryService.ContarProfissionaisPorStatus(request.Status);

        return new BuscarProfissionaisAdminResponse(profissionais, request.Pagina, profissionais.Length,
            totalProfissionais);
    }
}