using Traceability.Domain.ProductionEvents.Entities;
using Traceability.SharedKernel;

namespace Traceability.Domain.ProductionEvents.Errors;

public static class ProductionEventErrors
{
    private const string Base = nameof(ProductionEvent);

    public static readonly Error InvalidProductionEventType
        = new($"{Base}.{nameof(InvalidProductionEventType)}", "The provided ProductionEventType is invalid", ErrorType.Validation);
}
