using MediatR;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.QueryHandlers;

public class BuscarProfissionalPorUrlAmigavelQueryHandler : IRequestHandler<BuscarProfissionalPorUrlAmigavelQuery,
    BuscarProfissionalPorUrlAmigavelResponse>
{
    public BuscarProfissionalPorUrlAmigavelQueryHandler(
        IBuscarProfissionalPorUrlAmigavelQueryService buscarProfissionalPorUrlAmigavelQueryService)
    {
        BuscarProfissionalPorUrlAmigavelQueryService = buscarProfissionalPorUrlAmigavelQueryService;
    }

    private IBuscarProfissionalPorUrlAmigavelQueryService BuscarProfissionalPorUrlAmigavelQueryService { get; }

    public async Task<BuscarProfissionalPorUrlAmigavelResponse> Handle(BuscarProfissionalPorUrlAmigavelQuery request,
        CancellationToken cancellationToken)
    {
        var profissional =
            await BuscarProfissionalPorUrlAmigavelQueryService.BuscarProfissionalPorUrlAmigavel(request.UrlAmigavel);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        return profissional;
    }
}