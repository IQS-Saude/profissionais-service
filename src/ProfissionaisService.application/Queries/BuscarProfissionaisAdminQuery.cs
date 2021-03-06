using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Queries;

public class BuscarProfissionaisAdminQuery : IRequest<BuscarProfissionaisAdminResponse>
{
    public BuscarProfissionaisAdminQuery(int pagina, int limite, bool status, string? nome)
    {
        Pagina = pagina;
        Limite = limite;
        Status = status;
        Nome = nome;
    }

    public int Pagina { get; }
    public int Limite { get; }
    public bool Status { get; }
    public string? Nome { get; }
}