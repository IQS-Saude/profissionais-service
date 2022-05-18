using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.api.Dto;

public record BuscarProfissionaisAdminRequest(int Pagina = 1, int Limite = 10,
    [property: JsonConverter(typeof(StringBoolJsonConverter))]
    bool Status = true);