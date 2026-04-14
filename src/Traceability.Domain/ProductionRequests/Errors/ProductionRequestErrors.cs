using Traceability.Domain.ProductionRequests.Entities;

namespace Traceability.Domain.ProductionRequests.Errors;

public static class ProductionRequestErrors
{
    private const string Base = nameof(ProductionRequest);

    public static readonly Error InvalidRequestId
        = new($"{Base}.{nameof(InvalidRequestId)}", "The provided RequestId is invalid", ErrorType.Validation);
}
