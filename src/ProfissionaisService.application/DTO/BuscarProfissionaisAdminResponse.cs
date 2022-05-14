using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.application.DTO;

public record BuscarProfissionaisAdminResponse
    (ProfissionalAdmin[] Profissionais, int Pagina, int Quantidade, int Total);

public record ProfissionalAdmin(int Id, string Nome, int UnidadeId, int Visualizacoes,
    [property: JsonConverter(typeof(StringBoolJsonConverter))]
    bool Recomendado,
    [property: JsonConverter(typeof(StringBoolJsonConverter))]
    bool Status);