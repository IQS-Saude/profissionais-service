using MediatR;
using ProfissionaisService.application.DTO;

namespace ProfissionaisService.application.Queries;

public class BuscarProfissionalPorUrlAmigavelQuery : IRequest<BuscarProfissionalPorUrlAmigavelResponse>
{
    public BuscarProfissionalPorUrlAmigavelQuery(string urlAmigavel)
    {
        UrlAmigavel = urlAmigavel;
    }

    public string UrlAmigavel { get; }
}