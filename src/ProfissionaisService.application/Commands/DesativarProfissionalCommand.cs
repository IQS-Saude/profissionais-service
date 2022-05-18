using MediatR;

namespace ProfissionaisService.application.Commands;

public class DesativarProfissionalCommand : IRequest
{
    public DesativarProfissionalCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}