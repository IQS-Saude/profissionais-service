using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Queries;

public class BuscarWhatsappsPorProfissionalIdQuery : IRequest<List<WhatsappResponse>>
{
    public BuscarWhatsappsPorProfissionalIdQuery(int profissionalId)
    {
        ProfissionalId = profissionalId;
    }

    public int ProfissionalId { get; }
}