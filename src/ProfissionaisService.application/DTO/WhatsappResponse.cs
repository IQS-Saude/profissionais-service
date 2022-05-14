using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.application.DTO;

public record WhatsappResponse(long Numero, [property: JsonConverter(typeof(StringBoolJsonConverter))] bool Principal)
{
}