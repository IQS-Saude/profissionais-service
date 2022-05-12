namespace ProfissionaisService.domain.Exceptions;

public class WhatsappPrincipalDuplicadoException : Exception
{
    public WhatsappPrincipalDuplicadoException() : base("Não pode existir mais de um whatsapp principal")
    {
    }
}