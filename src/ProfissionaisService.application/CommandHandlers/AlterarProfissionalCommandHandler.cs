using MediatR;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Exceptions;
using ProfissionaisService.application.Ports;
using ProfissionaisService.domain.Aggregates.Profissional;
using ProfissionaisService.domain.Exceptions;

namespace ProfissionaisService.application.CommandHandlers;

public class
    AlterarProfissionalCommandHandler : IRequestHandler<AlterarProfissionalCommand, AlterarProfissionalResponse>
{
    public AlterarProfissionalCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<AlterarProfissionalResponse> Handle(AlterarProfissionalCommand request,
        CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.Id);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        await AlterarCampos(profissional, request);

        var profissionalAlterado = await ProfissionalRepository.Alterar(profissional);

        return new AlterarProfissionalResponse
        {
            Id = profissionalAlterado.Id,
            Nome = profissionalAlterado.Nome,
            UrlAmigavel = profissionalAlterado.UrlAmigavel,
            Sobre = profissionalAlterado.Sobre,
            Endereco = new EnderecoResponse(profissionalAlterado.Endereco.Estado, profissionalAlterado.Endereco.Cidade,
                profissionalAlterado.Endereco.Logradouro, profissional.Endereco.Numero,
                profissionalAlterado.Endereco.Bairro,
                profissionalAlterado.Endereco.Cep),
            TipoProfissionalId = profissionalAlterado.TipoProfissional.Id,
            UnidadeId = profissionalAlterado.UnidadeId,
            ImagemUrlPerfil = profissionalAlterado.ImagemUrlPerfil,
            Conselho = profissionalAlterado.Conselho,
            NumeroIdentificacao = profissionalAlterado.NumeroIdentificacao,
            Telefone = profissionalAlterado.Telefone,
            Celular = profissionalAlterado.Celular,
            Email = profissionalAlterado.Email,
            Site = profissionalAlterado.Site,
            Facebook = profissionalAlterado.Facebook,
            Instagram = profissionalAlterado.Instagram,
            Youtube = profissionalAlterado.Youtube,
            Linkedin = profissionalAlterado.Linkedin,
            Recomendado = profissionalAlterado.Recomendado,
            Status = profissionalAlterado.Status,
            Especialidades = profissionalAlterado.Especialidades.Select(especialidade => especialidade.Id).ToList()
        };
    }


    private async Task AlterarCampos(Profissional profissional,
        AlterarProfissionalCommand request)
    {
        AlterarEndereco(profissional, request.Endereco);
        await AlterarTipoProfissional(profissional, request.TipoProfissionalId);

        profissional.MudarNome(request.Nome);
        profissional.MudarUrlAmigavel(request.UrlAmigavel);
        profissional.MudarSobre(request.Sobre);
        profissional.MudarUnidadeId(request.UnidadeId);
        profissional.MudarImagemUrlPerfil(request.ImagemUrlPerfil);
        profissional.MudarConselho(request.Conselho);
        profissional.MudarNumeroIdentificacao(request.NumeroIdentificacao);
        profissional.MudarTelefone(request.Telefone);
        profissional.MudarCelular(request.Celular);
        profissional.MudarEmail(request.Email);
        profissional.MudarSite(request.Site);
        profissional.MudarFacebook(request.Facebook);
        profissional.MudarInstagram(request.Instagram);
        profissional.MudarYoutube(request.Youtube);
        profissional.MudarLinkedin(request.Linkedin);
        profissional.MudarRecomendado(request.Recomendado);
        profissional.MudarStatus(request.Status);

        await AlterarEspecialidades(profissional, request.Especialidades);
    }

    private void AlterarEndereco(Profissional profissional,
        AlterarProfissionalEndereco endereco)
    {
        var enderecoDomain = new Endereco(endereco.Logradouro, endereco.Numero, endereco.Bairro, endereco.Cidade,
            endereco.Estado, endereco.Cep);

        profissional.MudarEndereco(enderecoDomain);
    }

    private async Task AlterarTipoProfissional(Profissional profissional,
        int tipoProfissionalId)
    {
        var tipoProfissional = await ProfissionalRepository.BuscarTipoProfissionalPorId(tipoProfissionalId);

        if (tipoProfissional is null) throw new TipoProfissionalNaoEncontradoException();

        if (!Equals(tipoProfissional, profissional.TipoProfissional))
            profissional.MudarTipoProfissional(tipoProfissional);
    }

    private async Task AlterarEspecialidades(Profissional profissional,
        List<int> especialidades)
    {
        foreach (var especialidade in especialidades)
        {
            var especialidadeDomain = await ProfissionalRepository.BuscarEspecialidadePorId(especialidade);

            if (especialidadeDomain is null) throw new EspecialidadeNaoEncontradaException(especialidade);

            profissional.AdicionarEspecialidade(especialidadeDomain);
        }
    }
}