using MediatR;

namespace ProfissionaisService.application.Commands;

public class RemoverTratamentoCommand : IRequest<List<string>>
{
    public RemoverTratamentoCommand(int profissionalId, string descricao)
    {
        ProfissionalId = profissionalId;
        Descricao = descricao;
    }

    public int ProfissionalId { get; }
    public string Descricao { get; }
}