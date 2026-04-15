using Traceability.Domain.ProductionEvents.Entities;

namespace Traceability.Domain.ProductionEvents.Repositories;

public interface IProductionEventRepository : IBaseRepository<ProductionEvent>
{
    Task<IReadOnlyList<ProductionEvent>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductionEvent?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<ProductionEvent>> GetByProduductionRequestIdAsync(Guid productionRequestId, CancellationToken cancellationToken);
}
