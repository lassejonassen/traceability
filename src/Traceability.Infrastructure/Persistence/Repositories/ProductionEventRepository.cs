using Traceability.Domain.ProductionEvents.Entities;
using Traceability.Domain.ProductionEvents.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class ProductionEventRepository(ApplicationDbContext context)
    : BaseRepository<ProductionEvent>(context), IProductionEventRepository
{
    public Task<IReadOnlyList<ProductionEvent>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductionEvent?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
