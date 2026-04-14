using Traceability.Domain.ProcessSegments.Entities;

namespace Traceability.Domain.ProcessSegments.Errors;

public static class ProcessSegmentErrors
{
    private const string Base = nameof(ProcessSegment);

    public static readonly Error InvalidRequestId
        = new($"{Base}.{nameof(InvalidRequestId)}", "The provided Name is invalid", ErrorType.Validation);
}
