using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Queries;

namespace ProfissionaisService.application.Ports;

public interface IBuscarProfissionaisQueryService
{
    public Task<BuscarProfissionaisResponse> BuscarProfissionais(BuscarProfissionaisQuery query);
}