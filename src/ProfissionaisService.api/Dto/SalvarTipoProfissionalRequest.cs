using System.ComponentModel.DataAnnotations;

namespace ProfissionaisService.api.Dto;

public record SalvarTipoProfissionalRequest(int? Id, [Required(AllowEmptyStrings = false)] string Descricao,
    List<string> Especialidades);