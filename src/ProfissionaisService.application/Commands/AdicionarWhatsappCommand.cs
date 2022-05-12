using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Commands;

public class AdicionarWhatsappCommand : IRequest<List<WhatsappResponse>>
{
    public AdicionarWhatsappCommand(int profissionalId, long numero, bool principal)
    {
        ProfissionalId = profissionalId;
        Numero = numero;
        Principal = principal;
    }

    public int ProfissionalId { get; }
    public long Numero { get; }
    public bool Principal { get; }
}