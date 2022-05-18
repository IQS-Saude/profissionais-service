using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarWhatsappsPorProfissionalIdQueryService : IBuscarWhatsappsPorProfissionalIdQueryService
{
    private readonly ProfissionalContext _profissionalContext;

    public BuscarWhatsappsPorProfissionalIdQueryService(ProfissionalContext profissionalContext)
    {
        _profissionalContext = profissionalContext;
    }

    public async Task<List<WhatsappResponse>?> BuscarWhatsappsPorProfissionalId(int profissionalId)
    {
        return await _profissionalContext.Profissionais.Where(profissional => profissional.Id == profissionalId)
            .Select(profissional => profissional.Whatsapps
                .Select(whatsapp => new WhatsappResponse(whatsapp.Numero, whatsapp.Principal)).ToList())
            .FirstOrDefaultAsync();
    }
}