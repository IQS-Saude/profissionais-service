namespace ProfissionaisService.domain.Aggregates.Midias;

public class Imagem : MidiaAbstract
{
    public Imagem(string titulo, string url) : base(titulo, url, TipoMidia.Imagem)
    {
    }
}