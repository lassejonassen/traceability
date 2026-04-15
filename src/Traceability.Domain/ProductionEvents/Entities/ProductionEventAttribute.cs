using Traceability.Domain.ProductionEvents.Errors;

namespace Traceability.Domain.ProductionEvents.Entities;

public sealed class ProductionEventAttribute : BaseEntity
{
    private ProductionEventAttribute() { }
    private ProductionEventAttribute(DateTimeOffset utcNow) : base(utcNow) { }

    public string Name { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;
    public double NumericValue { get; private set; }

    public Guid ProductionEventId { get; init; }
    public ProductionEvent ProductionEvent { get; } = null!;

    public static Result<ProductionEventAttribute> Create(
        string name,
        string value,
        double numericValue,
        bool valueIsNumeric,
        Guid productionEventId,
        DateTimeOffset utcNow)
    {
        if (valueIsNumeric)
        {
            var valid = double.TryParse(value, out double result);

            if (!valid)
            {
                return Result.Failure<ProductionEventAttribute>(ProductionEventAttributeErrors.ValueIsNotNumeric);
            }
        }

        var productionEventAttribute = new ProductionEventAttribute(utcNow)
        {
            Name = name,
            Value = value,
            NumericValue = numericValue,
            ProductionEventId = productionEventId
        };

        return Result.Success(productionEventAttribute);
    }
}
