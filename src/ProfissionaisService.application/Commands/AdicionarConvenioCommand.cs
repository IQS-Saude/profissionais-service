using MediatR;

namespace ProfissionaisService.application.Commands;

public class AdicionarConvenioCommand : IRequest<List<string>>
{
    public AdicionarConvenioCommand(int profissionalId, string descricao)
    {
        ProfissionalId = profissionalId;
        Descricao = descricao;
    }

    public int ProfissionalId { get; }
    public string Descricao { get; }
}