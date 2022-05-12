using MediatR;

namespace ProfissionaisService.application.Commands;

public class RemoverProfissionalCommand : IRequest
{
    public RemoverProfissionalCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}