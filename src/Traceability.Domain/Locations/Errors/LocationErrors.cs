using Traceability.Domain.Locations.Entities;

namespace Traceability.Domain.Locations.Errors;

public static class LocationErrors
{
    private const string Base = nameof(Location);

    public static readonly Error InvalidRequestId
        = new($"{Base}.{nameof(InvalidRequestId)}", "The provided Name is invalid", ErrorType.Validation);
}
