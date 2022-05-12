using MediatR;
using ProfissionaisService.domain.Aggregates.TipoProfissional;

namespace ProfissionaisService.domain.Events;

public class EspecialidadeRemovidaEvent : INotification
{
    public EspecialidadeRemovidaEvent(Especialidade especialidadeRemovida, TipoProfissional tipoProfissional)
    {
        EspecialidadeRemovida = especialidadeRemovida;
        TipoProfissional = tipoProfissional;
    }

    public Especialidade EspecialidadeRemovida { get; }
    public TipoProfissional TipoProfissional { get; }
}