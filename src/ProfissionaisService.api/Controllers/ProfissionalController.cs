using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfissionaisService.api.Dto;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Queries;

namespace ProfissionaisService.api.Controllers;

[ApiController]
public class ProfissionalController : ApiController
{
    public ProfissionalController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }

    [HttpGet("/admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<BuscarProfissionaisAdminResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> ListarAdmin([FromQuery] BuscarProfissionaisAdminRequest request)
    {
        try
        {
            var response =
                await Mediator.Send(
                    new BuscarProfissionaisAdminQuery(request.Pagina, request.Limite, request.Status, request.Nome));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return StatusCode(500, Error(e.Message));
        }
    }


    [HttpPost("/admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<CriarProfissionalResponse>))]
    public async Task<IActionResult> Criar([FromBody] CriarProfissionalRequest request)
    {
        try
        {
            var response = await Mediator.Send(new CriarProfissionalCommand(request.Nome, request.UrlAmigavel,
                request.Sobre,
                new CriarProfissionalEndereco(request.Endereco.Logradouro, request.Endereco.Numero,
                    request.Endereco.Bairro,
                    request.Endereco.Cidade, request.Endereco.Estado, request.Endereco.Cep), request.TipoProfissionalId,
                request.UnidadeId, request.ImagemUrlPerfil, request.Conselho, request.NumeroIdentificacao,
                request.Telefone,
                request.Celular, request.Email, request.Site, request.Facebook, request.Instagram, request.Youtube,
                request.Linkedin, request.Recomendado, request.Status, request.EspecialidadesIds));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPatch("/admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<AlterarProfissionalResponse>))]
    public async Task<IActionResult> Alterar([FromBody] AlterarProfissionalRequest request)
    {
        try
        {
            var response = await Mediator.Send(new AlterarProfissionalCommand(request.Id, request.Nome,
                request.UrlAmigavel,
                request.Sobre,
                new AlterarProfissionalEndereco(request.Endereco.Logradouro, request.Endereco.Numero,
                    request.Endereco.Bairro,
                    request.Endereco.Cidade, request.Endereco.Estado, request.Endereco.Cep), request.TipoProfissionalId,
                request.UnidadeId, request.ImagemUrlPerfil, request.Conselho, request.NumeroIdentificacao,
                request.Telefone,
                request.Celular, request.Email, request.Site, request.Facebook, request.Instagram, request.Youtube,
                request.Linkedin, request.Recomendado, request.Status, request.EspecialidadesIds));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPatch("/admin/{id}/ativar")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<dynamic>))]
    public async Task<IActionResult> Ativar(int id)
    {
        try
        {
            await Mediator.Send(new AtivarProfissionalCommand(id));

            return Ok(Success(new { Message = "Profissional ativado!" }));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPatch("/admin/{id}/desativar")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<dynamic>))]
    public async Task<IActionResult> Desativar(int id)
    {
        try
        {
            await Mediator.Send(new DesativarProfissionalCommand(id));

            return Ok(Success(new { Message = "Profissional desativado!" }));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpGet("/admin/{id}/tratamentos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<string>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> BuscarTratamentos(int id)
    {
        try
        {
            var response = await Mediator.Send(new BuscarTratamentosPorProfissionalIdQuery(id));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return NotFound(Error(e.Message));
        }
    }

    [HttpPost("/admin/{id}/tratamentos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<string>>))]
    public async Task<IActionResult> AdicionarTratamento(int id, [FromForm] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new AdicionarTratamentoCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpDelete("/admin/{id}/tratamentos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<string>>))]
    public async Task<IActionResult> RemoverTratamento(int id, [FromForm] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new RemoverTratamentoCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpGet("/admin/{id}/convenios")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<string>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> BuscarConvenios(int id)
    {
        try
        {
            var response = await Mediator.Send(new BuscarConveniosPorProfissionalIdQuery(id));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return NotFound(Error(e.Message));
        }
    }

    [HttpPost("/admin/{id}/convenios")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<string>>))]
    public async Task<IActionResult> AdicionarConvenio(int id, [FromForm] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new AdicionarConvenioCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpDelete("/admin/{id}/convenios")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<string>>))]
    public async Task<IActionResult> RemoverConvenio(int id, [FromForm] string descricao)
    {
        try
        {
            var response = await Mediator.Send(new RemoverConvenioCommand(id, descricao));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpGet("/admin/{id}/whatsapps")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<WhatsappResponse>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> BuscarWhatsapps(int id)
    {
        try
        {
            var response = await Mediator.Send(new BuscarWhatsappsPorProfissionalIdQuery(id));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return NotFound(Error(e.Message));
        }
    }

    [HttpPost("/admin/{id}/whatsapps")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<WhatsappResponse>>))]
    public async Task<IActionResult> AdicionarWhatsapp(int id, [FromBody] WhatsappRequest request)
    {
        try
        {
            var response = await Mediator.Send(new AdicionarWhatsappCommand(id, request.Numero, request.Principal));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpDelete("/admin/{id}/whatsapps")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<List<WhatsappResponse>>))]
    public async Task<IActionResult> RemoverWhatsapp(int id, [FromBody] WhatsappRequest request)
    {
        try
        {
            var response = await Mediator.Send(new RemoverWhatsappCommand(id, request.Numero, request.Principal));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }


    [HttpGet("/site")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<BuscarProfissionaisResponse>))]
    public async Task<IActionResult> BuscarProfissionais([FromQuery] BuscarProfissionaisRequest request)
    {
        var response = await Mediator.Send(new BuscarProfissionaisQuery
        {
            Pagina = request.Pagina,
            Limite = request.Limite,
            UnidadeId = request.UnidadeId,
            Nome = request.Nome,
            TipoProfissionalId = request.TipoProfissionalId,
            EspecialidadeId = request.EspecialidadeId
        });

        return Ok(Success(response));
    }

    [HttpGet("/site/{urlAmigavel}")]
    [ProducesResponseType(StatusCodes.Status200OK,
        Type = typeof(SuccessResponse<BuscarProfissionalPorUrlAmigavelResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> BuscarProfissionalPorUrlAmigavel(
        string urlAmigavel)
    {
        try
        {
            var response = await Mediator.Send(new BuscarProfissionalPorUrlAmigavelQuery(urlAmigavel));
            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return NotFound(Error(e.Message));
        }
    }

    [HttpGet("/admin/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<BuscarProfissionalPorIdResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> BuscarProfissionalPorId(int id)
    {
        try
        {
            var response = await Mediator.Send(new BuscarProfissionalPorIdQuery(id));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return NotFound(Error(e.Message));
        }
    }

    [HttpGet("/dashboard")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<DashboardResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse<string>))]
    public async Task<IActionResult> Dashboard()
    {
        try
        {
            var response = await Mediator.Send(new DashboardQuery());

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }
}