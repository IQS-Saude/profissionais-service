using ProfissionaisService.domain.SeedWork;

namespace ProfissionaisService.domain.Aggregates.Midias;

public abstract class MidiaAbstract : ValueObject
{
    private int _tipoMidiaId;

    public MidiaAbstract(string titulo, string url, TipoMidia tipoMidia)
    {
        Titulo = titulo;
        Url = url;
        TipoMidia = tipoMidia;
    }

    public string Titulo { get; }
    public string Url { get; }
    public TipoMidia TipoMidia { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Titulo;
        yield return Url;
        yield return TipoMidia;
    }
}