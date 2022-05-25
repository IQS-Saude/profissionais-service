using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarProfissionalPorUrlAmigavelQueryService : IBuscarProfissionalPorUrlAmigavelQueryService
{
    public BuscarProfissionalPorUrlAmigavelQueryService(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<BuscarProfissionalPorUrlAmigavelResponse?> BuscarProfissionalPorUrlAmigavel(string urlAmigavel)
    {
        var result = await ProfissionalContext.Profissionais
            .Where(profissional => profissional.UrlAmigavel == urlAmigavel).Select(profissional =>
                new BuscarProfissionalPorUrlAmigavelResponse(profissional.Id, profissional.Nome, "",
                    new EnderecoResponse(profissional.Endereco.Estado, profissional.Endereco.Cidade,
                        profissional.Endereco.Logradouro, profissional.Endereco.Numero, profissional.Endereco.Bairro,
                        profissional.Endereco.Cep),
                    profissional.TipoProfissional.Descricao,
                    profissional.Especialidades.Select(e => e.Descricao).ToArray(), profissional.Conselho,
                    profissional.NumeroIdentificacao, profissional.Celular, profissional.Telefone,
                    profissional.Facebook, profissional.Instagram, profissional.Email, profissional.Site,
                    profissional.Sobre)).SingleOrDefaultAsync();

        return result;
    }
}