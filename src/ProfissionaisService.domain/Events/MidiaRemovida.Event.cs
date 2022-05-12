using MediatR;
using ProfissionaisService.domain.Aggregates.Midias;

namespace ProfissionaisService.domain.Events;

public class MidiaRemovidaEvent : INotification
{
    public MidiaRemovidaEvent(MidiaAbstract midiaRemovida)
    {
        MidiaRemovida = midiaRemovida;
    }

    public MidiaAbstract MidiaRemovida { get; }
}