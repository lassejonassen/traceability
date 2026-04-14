using Traceability.Domain.SegmentRequirements.Errors;

namespace Traceability.Domain.SegmentRequirements.Entities;

public sealed class SegmentRequirement : BaseEntity
{
    private SegmentRequirement() { }
    private SegmentRequirement(DateTimeOffset utcNow) : base(utcNow) { }

    public string RequirementId { get; private set; } = string.Empty;
   
    public static Result<SegmentRequirement> Create(string requirementId, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(requirementId))
        {
            return Result.Failure<SegmentRequirement>(SegmentRequirementErrors.InvalidRequestId);
        }

        var segmentRequirement = new SegmentRequirement(utcNow)
        {
            RequirementId = requirementId
        };

        return Result.Success(segmentRequirement);
    }
}
