using System.Text.Json.Serialization;
using ProfissionaisService.common.Json.Converters;

namespace ProfissionaisService.application.DTO;

public class BuscarProfissionaisResponse
{
    public BuscarProfissionaisResponse(ProfissionalResponse[] profissionais, int pagina, int quantidade, int total)
    {
        Profissionais = profissionais;
        Pagina = pagina;
        Quantidade = quantidade;
        Total = total;
    }

    public ProfissionalResponse[] Profissionais { get; }
    public int Pagina { get; }
    public int Quantidade { get; }
    public int Total { get; }
}

public class ProfissionalResponse
{
    public ProfissionalResponse(string nome, EnderecoResponse endereco, string urlAmigavel, string tipo,
        string[] especialidades, bool recomendado,
        string imagemPerfilUrl, int unidadeId, long? whatsapp, string? email, string? site, string? facebook,
        string? instagram, string? youtube, string? linkedin)
    {
        Nome = nome;
        Endereco = endereco;
        UrlAmigavel = urlAmigavel;
        Tipo = tipo;
        Especialidades = especialidades;
        Recomendado = recomendado;
        ImagemPerfilUrl = imagemPerfilUrl;
        UnidadeId = unidadeId;
        Whatsapp = whatsapp;
        Email = email;
        Site = site;
        Facebook = facebook;
        Instagram = instagram;
        Youtube = youtube;
        Linkedin = linkedin;
    }

    public string Nome { get; }
    public EnderecoResponse Endereco { get; }
    public string UrlAmigavel { get; }
    public string Tipo { get; }
    public string[] Especialidades { get; }

    [JsonConverter(typeof(StringBoolJsonConverter))]
    public bool Recomendado { get; }

    public string ImagemPerfilUrl { get; }
    public int UnidadeId { get; }
    public long? Whatsapp { get; }
    public string? Email { get; }
    public string? Site { get; }
    public string? Facebook { get; }
    public string? Instagram { get; }
    public string? Youtube { get; }
    public string? Linkedin { get; }
}