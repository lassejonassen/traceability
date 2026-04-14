using Traceability.Domain.ProductionRequests.Errors;

namespace Traceability.Domain.ProductionRequests.Entities;

public sealed class ProductionRequest : BaseEntity
{
	private ProductionRequest() { }
    private ProductionRequest(DateTimeOffset utcNow) : base(utcNow) { }

    public string RequestId { get; private set; } = string.Empty;

    public static Result<ProductionRequest> Create(string requestId, DateTimeOffset utcNow)
    {
        if (string.IsNullOrWhiteSpace(requestId))
        {
            return Result.Failure<ProductionRequest>(ProductionRequestErrors.InvalidRequestId);
        }

        var productionRequest = new ProductionRequest(utcNow)
        {
            RequestId = requestId
        };

        return Result.Success(productionRequest);
    }
}
