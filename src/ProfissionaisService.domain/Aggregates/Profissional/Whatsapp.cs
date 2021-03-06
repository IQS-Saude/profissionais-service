using ProfissionaisService.domain.SeedWork;

namespace ProfissionaisService.domain.Aggregates.Profissional;

public class Whatsapp : ValueObject
{
    public Whatsapp(long numero, bool principal = false)
    {
        Numero = numero;
        Principal = principal;
    }

    public long Numero { get; }
    public bool Principal { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Numero;
    }
}