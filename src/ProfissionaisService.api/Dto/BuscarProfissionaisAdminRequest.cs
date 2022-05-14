using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.api.Dto;

public class BuscarProfissionaisAdminRequest
{
    [JsonConverter(typeof(StringBoolJsonConverter))]
    public bool? Status { get; set; }

    public int Pagina { get; set; }
    public int Limite { get; set; }
}