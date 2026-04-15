using Traceability.Domain.ProcessSegments.Errors;
using Traceability.Domain.SegmentResponses.Entities;

namespace Traceability.Domain.ProcessSegments.Entities;

public sealed class ProcessSegment : BaseEntity
{
    private ProcessSegment() { }
    private ProcessSegment(DateTimeOffset utcNow) : base(utcNow) { }

    public string ProcessSegmentId { get; private set; } = string.Empty;

    private readonly List<SegmentResponse> _segmentResponses = [];
    public IReadOnlyList<SegmentResponse> SegmentResponses => _segmentResponses.AsReadOnly();

    public static Result<ProcessSegment> Create(string name, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<ProcessSegment>(ProcessSegmentErrors.InvalidRequestId);
        }

        var processSegment = new ProcessSegment(utcNow)
        {
            ProcessSegmentId = name
        };

        return Result.Success(processSegment);
    }
}
