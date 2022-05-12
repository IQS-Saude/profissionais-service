using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Queries;

public class BuscarProfissionalPorIdQuery : IRequest<BuscarProfissionalPorIdResponse>
{
    public BuscarProfissionalPorIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}