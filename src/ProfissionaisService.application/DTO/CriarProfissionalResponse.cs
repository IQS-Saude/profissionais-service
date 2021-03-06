using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.application.DTO;

public record CriarProfissionalResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string UrlAmigavel { get; set; }
    public string Sobre { get; set; }
    public EnderecoResponse Endereco { get; set; }
    public int TipoProfissionalId { get; set; }
    public int UnidadeId { get; set; }
    public string ImagemUrlPerfil { get; set; }
    public string? Conselho { get; set; }
    public string? NumeroIdentificacao { get; set; }
    public long? Telefone { get; set; }
    public long? Celular { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }
    public string? Facebook { get; set; }
    public string? Instagram { get; set; }
    public string? Youtube { get; set; }
    public string? Linkedin { get; set; }

    [JsonConverter(typeof(StringBoolJsonConverter))]
    public bool Recomendado { get; set; }

    [JsonConverter(typeof(StringBoolJsonConverter))]
    public bool Status { get; set; }

    public List<int> EspecialidadesIds { get; set; }
}