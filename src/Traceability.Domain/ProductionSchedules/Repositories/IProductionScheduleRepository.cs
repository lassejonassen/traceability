using Traceability.Domain.ProductionSchedules.Entities;

namespace Traceability.Domain.ProductionSchedules.Repositories;

public interface IProductionScheduleRepository : IBaseRepository<ProductionSchedule>
{
    Task<IReadOnlyList<ProductionSchedule>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductionSchedule?> GetAsync(string scheduleId, CancellationToken cancellationToken);
    Task<ProductionSchedule?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
