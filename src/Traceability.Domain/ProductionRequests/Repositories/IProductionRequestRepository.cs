using Traceability.Domain.ProductionRequests.Entities;

namespace Traceability.Domain.ProductionRequests.Repositories;

public interface IProductionRequestRepository : IBaseRepository<ProductionRequest>
{
    Task<IReadOnlyList<ProductionRequest>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductionRequest?> GetAsync(string requestId, CancellationToken cancellationToken);
    Task<ProductionRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
