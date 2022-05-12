namespace ProfissionaisService.api.Dto;

public record SalvarTipoProfissionalRequest(int? Id, string Descricao, List<string> Especialidades);