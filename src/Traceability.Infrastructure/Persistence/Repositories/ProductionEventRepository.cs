using Microsoft.EntityFrameworkCore;
using Traceability.Domain.ProductionEvents.Entities;
using Traceability.Domain.ProductionEvents.Repositories;
using Traceability.Domain.ProductionRequests.Entities;
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

    public async Task<IReadOnlyList<ProductionEvent>> GetByProduductionRequestIdAsync(Guid productionRequestId, CancellationToken cancellationToken)
    {
        return await DbContext.Set<ProductionEvent>()
            .Where(e => e.ProductionRequestId == productionRequestId)
            .ToListAsync(cancellationToken);
    }
}
