namespace ProfissionaisService.domain.Exceptions;

public class EspecialidadeNaoPertenceException : Exception
{
    public EspecialidadeNaoPertenceException() : base("Especialidade adicionada não pertence ao tipo do profissional")
    {
    }
}