using Traceability.Domain.SegmentResponses.Entities;

namespace Traceability.Domain.SegmentResponses.Repositories;

public interface ISegmentResponseRepository : IBaseRepository<SegmentResponse>
{
    Task<IReadOnlyList<SegmentResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<SegmentResponse?> GetAsync(string segmentId, CancellationToken cancellationToken);
    Task<SegmentResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
