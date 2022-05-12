using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Aggregates.Profissional;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class AdicionarTratamentoCommandHandler : IRequestHandler<AdicionarTratamentoCommand, List<string>>
{
    public AdicionarTratamentoCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<string>> Handle(AdicionarTratamentoCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.AdicionarTratamento(new Tratamento(request.Descricao));
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Tratamentos.Select(t => t.Descricao).ToList();
    }
}