using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Queries;

public class BuscarProfissionaisQuery : IRequest<BuscarProfissionaisResponse>
{
    public int Pagina { get; set; }
    public int Limite { get; set; }
    public int? UnidadeId { get; set; }
    public string? Nome { get; set; }
    public int? TipoProfissionalId { get; set; }
    public int? EspecialidadeId { get; set; }
}