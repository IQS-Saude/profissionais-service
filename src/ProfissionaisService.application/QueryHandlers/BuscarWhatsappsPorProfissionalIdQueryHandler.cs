using MediatR;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.QueryHandlers;

public class
    BuscarWhatsappsPorProfissionalIdQueryHandler : IRequestHandler<BuscarWhatsappsPorProfissionalIdQuery,
        List<WhatsappResponse>>
{
    private readonly IBuscarWhatsappsPorProfissionalIdQueryService _buscarWhatsappsPorProfissionalIdQueryService;

    public BuscarWhatsappsPorProfissionalIdQueryHandler(
        IBuscarWhatsappsPorProfissionalIdQueryService buscarWhatsappsPorProfissionalIdQueryService)
    {
        _buscarWhatsappsPorProfissionalIdQueryService = buscarWhatsappsPorProfissionalIdQueryService;
    }

    public async Task<List<WhatsappResponse>> Handle(BuscarWhatsappsPorProfissionalIdQuery request,
        CancellationToken cancellationToken)
    {
        var whatsapps =
            await _buscarWhatsappsPorProfissionalIdQueryService
                .BuscarWhatsappsPorProfissionalId(request.ProfissionalId);

        if (whatsapps is null) throw new ProfissionalNaoEncontradoException();

        return whatsapps;
    }
}