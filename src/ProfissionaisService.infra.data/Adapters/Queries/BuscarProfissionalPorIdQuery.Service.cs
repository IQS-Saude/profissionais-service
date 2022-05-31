using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarProfissionalPorIdQueryService : IBuscarProfissionalPorIdQueryService
{
    public BuscarProfissionalPorIdQueryService(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }

    public async Task<BuscarProfissionalPorIdResponse?> BuscarProfissionalPorId(int id)
    {
        var result = await ProfissionalContext.Profissionais
            .Where(profissional => profissional.Id == id).Select(profissional =>
                new BuscarProfissionalPorIdResponse(profissional.Id, profissional.Nome, profissional.UrlAmigavel,
                    profissional.UnidadeId, profissional.ImagemUrlPerfil,
                    new EnderecoResponse(profissional.Endereco.Estado, profissional.Endereco.Cidade,
                        profissional.Endereco.Logradouro, profissional.Endereco.Numero, profissional.Endereco.Bairro,
                        profissional.Endereco.Cep),
                    profissional.TipoProfissional.Id,
                    profissional.Especialidades.Select(e => e.Id).ToArray(), profissional.Conselho,
                    profissional.NumeroIdentificacao, profissional.Celular, profissional.Telefone,
                    profissional.Facebook, profissional.Instagram, profissional.Linkedin, profissional.Youtube,
                    profissional.Email, profissional.Site,
                    profissional.Sobre, profissional.Recomendado, profissional.Status)).SingleOrDefaultAsync();

        return result;
    }
}