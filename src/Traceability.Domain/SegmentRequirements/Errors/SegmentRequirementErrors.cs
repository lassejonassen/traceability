using Traceability.Domain.SegmentRequirements.Entities;

namespace Traceability.Domain.SegmentRequirements.Errors;

public static class SegmentRequirementErrors
{
    private const string Base = nameof(SegmentRequirement);

    public static readonly Error InvalidRequestId
        = new($"{Base}.{nameof(InvalidRequestId)}", "The provided RequirementId is invalid", ErrorType.Validation);
}
