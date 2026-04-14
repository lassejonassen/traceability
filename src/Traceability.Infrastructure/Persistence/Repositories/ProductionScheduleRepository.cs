using Microsoft.EntityFrameworkCore;
using Traceability.Domain.ProductionSchedules.Entities;
using Traceability.Domain.ProductionSchedules.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class ProductionScheduleRepository(ApplicationDbContext context)
    : BaseRepository<ProductionSchedule>(context), IProductionScheduleRepository
{
    public Task<IReadOnlyList<ProductionSchedule>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductionSchedule?> GetAsync(string scheduleId, CancellationToken cancellationToken)
    {
        return await DbContext.Set<ProductionSchedule>().FirstOrDefaultAsync(e => e.ScheduleId == scheduleId, cancellationToken);
    }

    public Task<ProductionSchedule?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
