namespace ProfissionaisService.application.DTO;

public class EnderecoResponse
{
    public EnderecoResponse(string estado, string cidade, string? logradouro, string? numero, string? bairro, long? cep)
    {
        Estado = estado;
        Cidade = cidade;
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cep = cep;
    }

    public string Estado { get; }
    public string Cidade { get; }
    public string? Logradouro { get; }
    public string? Numero { get; }
    public string? Bairro { get; }
    public long? Cep { get; }
}