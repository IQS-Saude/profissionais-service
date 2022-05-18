using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class DesativarProfissionalCommandHandler : IRequestHandler<DesativarProfissionalCommand>
{
    public DesativarProfissionalCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<Unit> Handle(DesativarProfissionalCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.Id);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.MudarStatus(false);
        await ProfissionalRepository.Alterar(profissional);

        return Unit.Value;
    }
}