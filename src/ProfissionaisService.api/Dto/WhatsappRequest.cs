using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.api.Dto;

public record WhatsappRequest
{
    public long Numero { get; set; }

    [JsonConverter(typeof(StringBoolConverter))]
    public bool Principal { get; set; }
}