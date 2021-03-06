using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.api.Dto;

public record CriarProfissionalRequest
{
    public string Nome { get; set; }
    public string UrlAmigavel { get; set; }
    public string Sobre { get; set; }
    public EnderecoRequest Endereco { get; set; }
    public int TipoProfissionalId { get; set; }
    public int UnidadeId { get; set; }
    public string ImagemUrlPerfil { get; set; }
    public string? Conselho { get; set; }
    public string? NumeroIdentificacao { get; set; }
    public long? Telefone { get; set; }
    public long? Celular { get; set; }

    [RegularExpression(
        @"[a-z\d!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z\d!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z\d](?:[a-z\d-]*[a-z\d])?\.)+[a-z\d](?:[a-z\d-]*[a-z\d])?",
        ErrorMessage = "email deve receber um E-mail valido")]
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