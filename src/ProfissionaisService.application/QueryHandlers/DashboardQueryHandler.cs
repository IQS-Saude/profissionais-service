using MediatR;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;

namespace ProfissionaisService.application.QueryHandlers;

public class DashboardQueryHandler : IRequestHandler<DashboardQuery, DashboardResponse>
{
    private readonly IDashboardQueryService _dashboardQueryService;

    public DashboardQueryHandler(IDashboardQueryService dashboardQueryService)
    {
        _dashboardQueryService = dashboardQueryService;
    }

    public async Task<DashboardResponse> Handle(DashboardQuery request, CancellationToken cancellationToken)
    {
        return await _dashboardQueryService.BuscarDadosDashboard();
    }
}