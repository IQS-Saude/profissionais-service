using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class AtivarProfissionalCommandHandler : IRequestHandler<AtivarProfissionalCommand>
{
    public AtivarProfissionalCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<Unit> Handle(AtivarProfissionalCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.Id);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.MudarStatus(true);
        await ProfissionalRepository.Alterar(profissional);

        return Unit.Value;
    }
}