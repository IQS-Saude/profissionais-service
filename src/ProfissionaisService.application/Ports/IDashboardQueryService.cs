using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Ports;

public interface IDashboardQueryService
{
    public Task<DashboardResponse> BuscarDadosDashboard();
}