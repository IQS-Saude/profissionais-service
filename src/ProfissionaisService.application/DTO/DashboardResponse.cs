namespace ProfissionaisService.application.DTO;

public record DashboardResponse(int Ativos, int Inativos, string Nome = "profissionais");