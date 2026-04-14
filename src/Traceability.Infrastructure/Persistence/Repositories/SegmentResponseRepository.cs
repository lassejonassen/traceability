using Microsoft.EntityFrameworkCore;
using Traceability.Domain.SegmentResponses.Entities;
using Traceability.Domain.SegmentResponses.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class SegmentResponseRepository(ApplicationDbContext context)
    : BaseRepository<SegmentResponse>(context), ISegmentResponseRepository
{
    public Task<IReadOnlyList<SegmentResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<SegmentResponse?> GetAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext.Set<SegmentResponse>().FirstOrDefaultAsync(e => e.SegmentId == name, cancellationToken); throw new NotImplementedException();
    }

    public Task<SegmentResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
