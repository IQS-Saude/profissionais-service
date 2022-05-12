using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Aggregates.Profissional;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class AdicionarWhatsappCommandHandler : IRequestHandler<AdicionarWhatsappCommand, List<WhatsappResponse>>
{
    public AdicionarWhatsappCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<WhatsappResponse>> Handle(AdicionarWhatsappCommand request,
        CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.AdicionarWhatsapp(new Whatsapp(request.Numero, request.Principal));
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Whatsapps.Select(whatsapp => new WhatsappResponse(whatsapp.Numero, whatsapp.Principal))
            .ToList();
    }
}