using Traceability.Application.ProductionEvents.DTOs;
using Traceability.Domain.ProductionEvents.Enums;
using Traceability.Domain.ProductionEvents.Repositories;
using Traceability.Domain.ProductionRequests.Errors;
using Traceability.Domain.ProductionRequests.Repositories;
using Traceability.SharedKernel;

namespace Traceability.Application.ProductionEvents.Queries;

public sealed record GetProductionEventTraceQuery(Guid ProductionRequestId) : IRequest<Result<ProductionEventTraceDTO>>;

public sealed record GetProductionEventTraceQueryHandler(
    IProductionRequestRepository productionRequestRepository,
    IProductionEventRepository productionEventRepository)
    : IRequestHandler<GetProductionEventTraceQuery, Result<ProductionEventTraceDTO>>
{
    public async Task<Result<ProductionEventTraceDTO>> Handle(GetProductionEventTraceQuery request, CancellationToken cancellationToken)
    {
        var productionRequest = await productionRequestRepository.GetByIdAsync(request.ProductionRequestId, cancellationToken);

        if (productionRequest is null)
        {
            return Result.Failure<ProductionEventTraceDTO>(ProductionRequestErrors.NotFound);
        }

        var productionEvents = await productionEventRepository.GetByProduductionRequestIdAsync(productionRequest.Id, cancellationToken);

        var produceProductionEvents = productionEvents
            .Select(x => x.ProductionEventType == ProductionEventType.MaterialProduced)
            .ToList();

        return new ProductionEventTraceDTO { ProductionRequestId = productionRequest.RequestId };
    }
}
