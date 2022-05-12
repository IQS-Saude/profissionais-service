using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Aggregates.Profissional;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class RemoverConvenioCommandHandler : IRequestHandler<RemoverConvenioCommand, List<string>>
{
    public RemoverConvenioCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<string>> Handle(RemoverConvenioCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.RemoverConvenio(new Convenio(request.Descricao));
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Convenios.Select(c => c.Descricao).ToList();
    }
}