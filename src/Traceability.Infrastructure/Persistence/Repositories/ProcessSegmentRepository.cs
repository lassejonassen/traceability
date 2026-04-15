using Microsoft.EntityFrameworkCore;
using Traceability.Domain.Materials.Entities;
using Traceability.Domain.ProcessSegments.Entities;
using Traceability.Domain.ProcessSegments.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class ProcessSegmentRepository(ApplicationDbContext context)
    : BaseRepository<ProcessSegment>(context), IProcessSegmentRepository
{
    public Task<IReadOnlyList<ProcessSegment>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ProcessSegment?> GetAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext.Set<ProcessSegment>().FirstOrDefaultAsync(e => e.ProcessSegmentId == name, cancellationToken);
    }

    public Task<ProcessSegment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
