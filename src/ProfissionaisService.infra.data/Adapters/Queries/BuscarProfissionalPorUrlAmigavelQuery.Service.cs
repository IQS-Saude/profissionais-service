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
                new BuscarProfissionalPorUrlAmigavelResponse(profissional.Nome, profissional.UrlAmigavel,
                    profissional.UnidadeId, profissional.ImagemUrlPerfil,
                    new EnderecoResponse(profissional.Endereco.Estado, profissional.Endereco.Cidade,
                        profissional.Endereco.Logradouro, profissional.Endereco.Numero, profissional.Endereco.Bairro,
                        profissional.Endereco.Cep),
                    profissional.TipoProfissional.Descricao,
                    profissional.Especialidades.Select(e => e.Descricao).ToArray(),
                    profissional.Tratamentos.Select(t => t.Descricao).ToArray(),
                    profissional.Convenios.Select(c => c.Descricao).ToArray(),
                    profissional.Whatsapps.Select(w => new WhatsappResponse(w.Numero, w.Principal)).ToArray(),
                    profissional.Conselho,
                    profissional.NumeroIdentificacao, profissional.Celular, profissional.Telefone,
                    profissional.Facebook, profissional.Instagram, profissional.Youtube, profissional.Linkedin,
                    profissional.Email, profissional.Site,
                    profissional.Sobre, profissional.Recomendado)).SingleOrDefaultAsync();

        return result;
    }
}