using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.application.DTO;

public class BuscarProfissionalPorUrlAmigavelResponse
{
    public BuscarProfissionalPorUrlAmigavelResponse(string nome, string urlAmigavel, int unidadeId,
        string imagemPerfilUrl,
        EnderecoResponse endereco, string tipo, string[] especialidades, string[] tratamentos, string[] convenios,
        WhatsappResponse[] whatsapps, string? conselho, string? numeroIdentificacao,
        long? celular, long? telefone, string? facebook, string? instagram, string? youtube, string? linkedin,
        string? email, string? site, string? sobre, bool recomendado)
    {
        Nome = nome;
        UrlAmigavel = urlAmigavel;
        UnidadeId = unidadeId;
        ImagemPerfilUrl = imagemPerfilUrl;
        Endereco = endereco;
        Tipo = tipo;
        Especialidades = especialidades;
        Tratamentos = tratamentos;
        Convenios = convenios;
        Conselho = conselho;
        Whatsapps = whatsapps;
        NumeroIdentificacao = numeroIdentificacao;
        Celular = celular;
        Telefone = telefone;
        Facebook = facebook;
        Instagram = instagram;
        Youtube = youtube;
        Linkedin = linkedin;
        Email = email;
        Site = site;
        Sobre = sobre;
        Recomendado = recomendado;
    }

    public string Nome { get; }
    public string UrlAmigavel { get; }
    public int UnidadeId { get; }
    public string ImagemPerfilUrl { get; }
    public EnderecoResponse Endereco { get; }
    public string Tipo { get; }
    public string[] Especialidades { get; }
    public string[] Tratamentos { get; }
    public string[] Convenios { get; }
    public WhatsappResponse[] Whatsapps { get; }
    public string? Conselho { get; }
    public string? NumeroIdentificacao { get; }
    public long? Celular { get; }
    public long? Telefone { get; }
    public string? Facebook { get; }
    public string? Instagram { get; }
    public string? Youtube { get; }
    public string? Linkedin { get; }
    public string? Email { get; }
    public string? Site { get; }
    public string? Sobre { get; }

    [JsonConverter(typeof(StringBoolJsonConverter))]
    public bool Recomendado { get; }
}