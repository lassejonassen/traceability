using Traceability.Domain.SegmentRequirements.Entities;

namespace Traceability.Domain.SegmentRequirements.Repositories;

public interface ISegmentRequirementRepository : IBaseRepository<SegmentRequirement>
{
    Task<IReadOnlyList<SegmentRequirement>> GetAllAsync(CancellationToken cancellationToken);
    Task<SegmentRequirement?> GetAsync(string requirementId, CancellationToken cancellationToken);
    Task<SegmentRequirement?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
