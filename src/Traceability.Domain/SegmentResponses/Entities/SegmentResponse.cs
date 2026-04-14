using Traceability.Domain.SegmentResponses.Errors;

namespace Traceability.Domain.SegmentResponses.Entities;

public sealed class SegmentResponse : BaseEntity
{
    private SegmentResponse() { }
    private SegmentResponse(DateTimeOffset utcNow) : base(utcNow) { }

    public Guid ProcessSegmentId { get; private set; }
    public string SegmentId { get; private set; } = string.Empty;

    public static Result<SegmentResponse> Create(string responseId, Guid processSegmentId, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(responseId))
        {
            return Result.Failure<SegmentResponse>(SegmentResponseErrors.InvalidRequestId);
        }

        var segmentResponse = new SegmentResponse(utcNow)
        {
            SegmentId = responseId,
            ProcessSegmentId = processSegmentId
        };

        return Result.Success(segmentResponse);
    }
}
