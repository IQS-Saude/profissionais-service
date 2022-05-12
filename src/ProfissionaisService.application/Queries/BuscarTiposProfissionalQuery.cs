using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Queries;

public class BuscarTiposProfissionalQuery : IRequest<List<BuscarTiposProfissionalResponse>>
{
}