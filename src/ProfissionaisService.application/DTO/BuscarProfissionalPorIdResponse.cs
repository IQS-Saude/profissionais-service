using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.application.DTO;

public class BuscarProfissionalPorIdResponse
{
    public BuscarProfissionalPorIdResponse(int id, string nome, string urlAmigavel, int unidadeId,
        string imagemUrlPerfil,
        EnderecoResponse endereco, int tipoProfissionalId, int[] especialidadesIds, string? conselho,
        string? numeroIdentificacao,
        long? celular, long? telefone, string? facebook, string? instagram, string? linkedin, string? youtube,
        string? email, string? site, string? sobre, bool recomendado, bool status)
    {
        Id = id;
        Nome = nome;
        UrlAmigavel = urlAmigavel;
        UnidadeId = unidadeId;
        ImagemUrlPerfil = imagemUrlPerfil;
        Endereco = endereco;
        TipoProfissionalId = tipoProfissionalId;
        EspecialidadesIds = especialidadesIds;
        Conselho = conselho;
        NumeroIdentificacao = numeroIdentificacao;
        Celular = celular;
        Telefone = telefone;
        Facebook = facebook;
        Instagram = instagram;
        Linkedin = linkedin;
        Youtube = youtube;
        Email = email;
        Site = site;
        Sobre = sobre;
        Recomendado = recomendado;
        Status = status;
    }

    public int Id { get; }
    public string Nome { get; }
    public string UrlAmigavel { get; }
    public int UnidadeId { get; }
    public string ImagemUrlPerfil { get; }
    public EnderecoResponse Endereco { get; }
    public int TipoProfissionalId { get; }
    public int[] EspecialidadesIds { get; }
    public string? Conselho { get; }
    public string? NumeroIdentificacao { get; }
    public long? Celular { get; }
    public long? Telefone { get; }
    public string? Facebook { get; }
    public string? Instagram { get; }
    public string? Linkedin { get; }
    public string? Youtube { get; }
    public string? Email { get; }
    public string? Site { get; }
    public string? Sobre { get; }

    [JsonConverter(typeof(StringBoolJsonConverter))]
    public bool Recomendado { get; }

    [JsonConverter(typeof(StringBoolJsonConverter))]
    public bool Status { get; }
}