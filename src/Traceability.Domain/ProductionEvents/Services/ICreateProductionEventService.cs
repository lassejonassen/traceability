using Traceability.Domain.ProductionEvents.DTOs;
using Traceability.Domain.ProductionEvents.Entities;
using Traceability.SharedKernel;

namespace Traceability.Domain.ProductionEvents.Services;

public interface ICreateProductionEventService
{
    Task<Result<ProductionEvent>> CreateAsync(ProductionEventCaptureDTO data, DateTimeOffset utcNow, CancellationToken cancellationToken);
}
