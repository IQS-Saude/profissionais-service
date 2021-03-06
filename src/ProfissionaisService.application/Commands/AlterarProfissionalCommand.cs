using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Commands;

public class AlterarProfissionalEndereco
{
    public AlterarProfissionalEndereco(string? logradouro, string? numero, string? bairro, string cidade, string estado,
        long? cep)
    {
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public string? Logradouro { get; }
    public string? Numero { get; }
    public string? Bairro { get; }
    public string Cidade { get; }
    public string Estado { get; }
    public long? Cep { get; }
}

public class AlterarProfissionalCommand : IRequest<AlterarProfissionalResponse>
{
    public AlterarProfissionalCommand(int id, string nome, string urlAmigavel, string sobre,
        AlterarProfissionalEndereco endereco,
        int tipoProfissionalId, int unidadeId, string imagemUrlPerfil, string? conselho, string? numeroIdentificacao,
        long? telefone, long? celular, string? email, string? site, string? facebook, string? instagram,
        string? youtube, string? linkedin, bool recomendado, bool status, List<int> especialidades)
    {
        Id = id;
        Nome = nome;
        UrlAmigavel = urlAmigavel;
        Sobre = sobre;
        Endereco = endereco;
        TipoProfissionalId = tipoProfissionalId;
        UnidadeId = unidadeId;
        ImagemUrlPerfil = imagemUrlPerfil;
        Conselho = conselho;
        NumeroIdentificacao = numeroIdentificacao;
        Telefone = telefone;
        Celular = celular;
        Email = email;
        Site = site;
        Facebook = facebook;
        Instagram = instagram;
        Youtube = youtube;
        Linkedin = linkedin;
        Recomendado = recomendado;
        Status = status;
        Especialidades = especialidades;
    }

    public int Id { get; }
    public string Nome { get; }
    public string UrlAmigavel { get; }
    public string Sobre { get; }
    public AlterarProfissionalEndereco Endereco { get; }
    public int TipoProfissionalId { get; }
    public int UnidadeId { get; }
    public string ImagemUrlPerfil { get; }
    public string? Conselho { get; }
    public string? NumeroIdentificacao { get; }
    public long? Telefone { get; }
    public long? Celular { get; }
    public string? Email { get; }
    public string? Site { get; }
    public string? Facebook { get; }
    public string? Instagram { get; }
    public string? Youtube { get; }
    public string? Linkedin { get; }
    public bool Recomendado { get; }
    public bool Status { get; }
    public List<int> Especialidades { get; }
}