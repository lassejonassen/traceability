using Traceability.Domain.ProductionEvents.Entities;

namespace Traceability.Domain.ProductionEvents.Errors;

public static class ProductionEventAttributeErrors
{
    private const string Base = nameof(ProductionEventAttribute);

    public static readonly Error ValueIsNotNumeric
        = new($"{Base}.{nameof(ValueIsNotNumeric)}", "The provided value is not numeric", ErrorType.Validation);
}
