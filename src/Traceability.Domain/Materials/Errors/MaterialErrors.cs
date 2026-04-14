using Traceability.Domain.Materials.Entities;

namespace Traceability.Domain.Materials.Errors;

public static class MaterialErrors
{
    private const string Base = nameof(Material);

    public static readonly Error InvalidRequestId
        = new($"{Base}.{nameof(InvalidRequestId)}", "The provided Name is invalid", ErrorType.Validation);
}
