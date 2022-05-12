using MediatR;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.QueryHandlers;

public class
    BuscarProfissionalPorIdQueryHandler : IRequestHandler<BuscarProfissionalPorIdQuery, BuscarProfissionalPorIdResponse>
{
    public BuscarProfissionalPorIdQueryHandler(IBuscarProfissionalPorIdQueryService buscarProfissionalPorIdQueryService)
    {
        BuscarProfissionalPorIdQueryService = buscarProfissionalPorIdQueryService;
    }

    private IBuscarProfissionalPorIdQueryService BuscarProfissionalPorIdQueryService { get; }

    public async Task<BuscarProfissionalPorIdResponse> Handle(BuscarProfissionalPorIdQuery request,
        CancellationToken cancellationToken)
    {
        var profissional =
            await BuscarProfissionalPorIdQueryService.BuscarProfissionalPorId(request.Id);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        return profissional;
    }
}