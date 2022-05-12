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
                new BuscarProfissionalPorIdResponse(profissional.Id, profissional.Nome, "",
                    new EnderecoResponse(profissional.Endereco.Estado, profissional.Endereco.Cidade,
                        profissional.Endereco.Logradouro, profissional.Endereco.Bairro, profissional.Endereco.Cep),
                    profissional.TipoProfissional.Descricao,
                    profissional.Especialidades.Select(e => e.Descricao).ToArray(), profissional.Conselho,
                    profissional.NumeroIdentificacao, profissional.Celular, profissional.Telefone,
                    profissional.Facebook, profissional.Instagram, profissional.Email, profissional.Site,
                    profissional.Sobre)).SingleOrDefaultAsync();

        return result;
    }
}