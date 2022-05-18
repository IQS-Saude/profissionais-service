using MediatR;

namespace ProfissionaisService.application.Commands;

public class AtivarProfissionalCommand : IRequest
{
    public AtivarProfissionalCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}