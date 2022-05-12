using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class RemoverProfissionalCommandHandler : IRequestHandler<RemoverProfissionalCommand>
{
    public RemoverProfissionalCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<Unit> Handle(RemoverProfissionalCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.Id);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        await ProfissionalRepository.Remover(profissional);

        return Unit.Value;
    }
}