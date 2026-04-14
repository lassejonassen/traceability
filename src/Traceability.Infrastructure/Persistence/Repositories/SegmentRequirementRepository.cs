using Microsoft.EntityFrameworkCore;
using Traceability.Domain.ProductionRequests.Entities;
using Traceability.Domain.SegmentRequirements.Entities;
using Traceability.Domain.SegmentRequirements.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.Infrastructure.Persistence.Repositories;

internal sealed class SegmentRequirementRepository(ApplicationDbContext context)
    : BaseRepository<SegmentRequirement>(context), ISegmentRequirementRepository
{
    public Task<IReadOnlyList<SegmentRequirement>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<SegmentRequirement?> GetAsync(string name, CancellationToken cancellationToken)
    {
        return await DbContext.Set<SegmentRequirement>().FirstOrDefaultAsync(e => e.RequirementId == name, cancellationToken); throw new NotImplementedException();
    }

    public Task<SegmentRequirement?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
