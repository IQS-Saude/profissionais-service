using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfissionaisService.api.Dto;
using ProfissionaisService.application.Commands;
using ProfissionaisService.application.DTO;
using ProfissionaisService.application.Queries;

namespace ProfissionaisService.api.Controllers;

[ApiController]
[Route("tipos-profissional")]
public class TiposProfissionalController : ApiController
{
    public TiposProfissionalController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,
        Type = typeof(SuccessResponse<List<BuscarTiposProfissionalResponse>>))]
    public async Task<IActionResult> Buscar()
    {
        try
        {
            var response = await Mediator.Send(new BuscarTiposProfissionalQuery());

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK,
        Type = typeof(SuccessResponse<SalvarTipoProfissionalResponse>))]
    public async Task<IActionResult> Salvar([FromBody] SalvarTipoProfissionalRequest request)
    {
        try
        {
            var response =
                await Mediator.Send(
                    new SalvarTipoProfissionalCommand(request.Id, request.Descricao, request.Especialidades));

            return Ok(Success(response));
        }
        catch (Exception e)
        {
            return BadRequest(Error(e.Message));
        }
    }
}