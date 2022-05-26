using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Aggregates.Profissional;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class AdicionarConvenioCommandHandler : IRequestHandler<AdicionarConvenioCommand, List<string>>
{
    public AdicionarConvenioCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<string>> Handle(AdicionarConvenioCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.AdicionarConvenio(new Convenio(request.Descricao));
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Convenios.Select(e => e.Descricao).ToList();
    }
}