using Traceability.Domain.ProcessSegments.Entities;

namespace Traceability.Domain.ProcessSegments.Repositories;

public interface IProcessSegmentRepository : IBaseRepository<ProcessSegment>
{
    Task<IReadOnlyList<ProcessSegment>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProcessSegment?> GetAsync(string name, CancellationToken cancellationToken);
    Task<ProcessSegment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
