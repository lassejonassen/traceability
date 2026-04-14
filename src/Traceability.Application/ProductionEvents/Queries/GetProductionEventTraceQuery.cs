using Traceability.Application.ProductionEvents.DTOs;
using Traceability.Domain.ProductionEvents.Repositories;

namespace Traceability.Application.ProductionEvents.Queries;

public sealed record GetProductionEventTraceQuery(string ProductionRequestId) : IRequest<ProductionEventTraceDTO>;

public sealed record GetProductionEventTraceQueryHandler(
    IProductionEventRepository ProductionEventRepository)
    : IRequestHandler<GetProductionEventTraceQuery, ProductionEventTraceDTO>
{
    public async Task<ProductionEventTraceDTO> Handle(GetProductionEventTraceQuery request, CancellationToken cancellationToken)
    {
        return new ProductionEventTraceDTO { ProductionRequestId = request.ProductionRequestId };
    }
}
