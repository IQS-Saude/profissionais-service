using ProfissionaisService.domain.SeedWork;

namespace ProfissionaisService.domain.Aggregates.Profissional;

public class Convenio : ValueObject
{
    public Convenio(string descricao)
    {
        Descricao = descricao;
    }


    public string Descricao { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Descricao;
    }
}