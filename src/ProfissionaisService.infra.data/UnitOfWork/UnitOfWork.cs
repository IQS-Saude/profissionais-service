using ProfissionaisService.domain.SeedWork;

namespace ProfissionaisService.infra.data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}