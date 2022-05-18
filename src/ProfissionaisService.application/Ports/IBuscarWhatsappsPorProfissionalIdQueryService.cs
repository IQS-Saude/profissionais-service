using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Ports;

public interface IBuscarWhatsappsPorProfissionalIdQueryService
{
    public Task<List<WhatsappResponse>?> BuscarWhatsappsPorProfissionalId(int profissionalId);
}