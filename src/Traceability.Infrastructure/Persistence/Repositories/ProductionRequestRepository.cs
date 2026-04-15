using Microsoft.EntityFrameworkCore;
using Traceability.Domain.ProcessSegments.Entities;
using Traceability.Domain.ProductionRequests.Entities;
using Traceability.Domain.ProductionRequests.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class ProductionRequestRepository(ApplicationDbContext context)
    : BaseRepository<ProductionRequest>(context), IProductionRequestRepository
{
    public Task<IReadOnlyList<ProductionRequest>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductionRequest?> GetAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext.Set<ProductionRequest>().FirstOrDefaultAsync(e => e.RequestId == name, cancellationToken); throw new NotImplementedException();
    }

    public async Task<ProductionRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<ProductionRequest>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}
