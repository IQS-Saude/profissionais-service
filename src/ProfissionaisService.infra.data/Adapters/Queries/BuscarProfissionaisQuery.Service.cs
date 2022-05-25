using Microsoft.EntityFrameworkCore;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Ports;
using ProfissionaisService.application.Queries;
using ProfissionaisService.infra.data.Data;

namespace ProfissionaisService.infra.data.Adapters.Queries;

public class BuscarProfissionaisQueryService : IBuscarProfissionaisQueryService
{
    public BuscarProfissionaisQueryService(ProfissionalContext profissionalContext)
    {
        ProfissionalContext = profissionalContext;
    }

    private ProfissionalContext ProfissionalContext { get; }


    public async Task<BuscarProfissionaisResponse> BuscarProfissionais(BuscarProfissionaisQuery query)
    {
        var totalProfissionais = await ContarProfissionaisAtivos();

        var dbQuery = ProfissionalContext.Profissionais.Where(profissional => profissional.Status)
            .Skip((query.Pagina - 1) * query.Limite).Take(query.Limite);

        if (query.Nome is not null) dbQuery = dbQuery.Where(profissional => profissional.Nome.Contains(query.Nome));

        if (query.UnidadeId is not null)
            dbQuery = dbQuery.Where(profissional => profissional.UnidadeId == query.UnidadeId);

        if (query.EspecialidadeId is not null)
            dbQuery = dbQuery.Where(profissional =>
                profissional.Especialidades.Any(especialidade => especialidade.Id == query.EspecialidadeId));

        if (query.TipoProfissionalId is not null)
            dbQuery = dbQuery.Where(profissional => profissional.TipoProfissional.Id == query.TipoProfissionalId);

        //TODO COrrigir esse erro nullable
        var profissionais = await dbQuery.Select(profissional => new ProfissionalResponse(profissional.Nome,
            new EnderecoResponse(profissional.Endereco.Estado, profissional.Endereco.Cidade,
                profissional.Endereco.Logradouro, profissional.Endereco.Numero, profissional.Endereco.Bairro,
                profissional.Endereco.Cep),
            profissional.UrlAmigavel, profissional.TipoProfissional.Descricao,
            profissional.Especialidades.Select(e => e.Descricao).ToArray(), profissional.Recomendado,
            profissional.ImagemUrlPerfil,
            profissional.UnidadeId,
            profissional.Whatsapps.FirstOrDefault(w => w.Principal).Numero, profissional.Email, profissional.Site,
            profissional.Facebook, profissional.Instagram, profissional.Youtube, profissional.Linkedin)).ToArrayAsync();

        return new BuscarProfissionaisResponse(profissionais, query.Pagina, profissionais.Length, totalProfissionais);
    }

    public async Task<int> ContarProfissionaisAtivos()
    {
        return await ProfissionalContext.Profissionais.CountAsync(profissional => profissional.Status);
    }
}