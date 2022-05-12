namespace ProfissionaisService.domain.Exceptions;

public class WhatsappPrincipalNaoExisteException : Exception
{
    public WhatsappPrincipalNaoExisteException() : base("Whatsapp principal não existe na lista de whatsapps")
    {
    }
}