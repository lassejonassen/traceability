using Traceability.Domain.SegmentResponses.Entities;

namespace Traceability.Domain.SegmentResponses.Errors;

public static class SegmentResponseErrors
{
    private const string Base = nameof(SegmentResponse);

    public static readonly Error InvalidRequestId
        = new($"{Base}.{nameof(InvalidRequestId)}", "The provided ResponseId is invalid", ErrorType.Validation);
}
