using System;
using System.Collections.Generic;
using System.Text;
using Traceability.Application.ProductionEvents.DTOs;
using Traceability.Domain.ProductionEvents.Repositories;
using Traceability.Domain.ProductionRequests.Errors;
using Traceability.Domain.ProductionRequests.Repositories;
using Traceability.SharedKernel;

namespace Traceability.Application.ProductionEvents.Queries;

public sealed record GetProductionEventsByProductionRequestIdQuery(Guid ProductionRequestId) : IRequest<Result<IReadOnlyList<ProductionEventNodeDTO>>>;

public sealed class GetProductionEventsByProductionRequestIdQueryHandler(
     IProductionRequestRepository productionRequestRepository,
    IProductionEventRepository productionEventRepository)
    : IRequestHandler<GetProductionEventsByProductionRequestIdQuery, Result<IReadOnlyList<ProductionEventNodeDTO>>>
{
    public async Task<Result<IReadOnlyList<ProductionEventNodeDTO>>> Handle(GetProductionEventsByProductionRequestIdQuery request, CancellationToken cancellationToken)
    {
        var productionRequest = await productionRequestRepository.GetByIdAsync(request.ProductionRequestId, cancellationToken);

        if (productionRequest is null)
        {
            return Result.Failure<IReadOnlyList<ProductionEventNodeDTO>>(ProductionRequestErrors.NotFound);
        }

        var productionEvents = await productionEventRepository.GetByProduductionRequestIdAsync(productionRequest.Id, cancellationToken);

        var dtos = productionEvents.Select(e => new ProductionEventNodeDTO
        {
            Comment = e.Comment,
            Equipment = e.Equipment.Name,
            EventId = e.EventId,
            EventType = e.ProductionEventType.ToString(),
            Id = e.Id,
            Location = e.Location.Name,
            Lot = e.Lot,
            Material = e.Material.Name,
            ProductionRequestId = e.ProductionRequest.RequestId,
            ProductionScheduleId = e.ProductionSchedule.ScheduleId,
            Quantity = e.Quantity.ToString(),
            SegmentRequirementId = e.SegmentRequirement.RequirementId,
            SegmentResponseId = e.SegmentResponse.SegmentResponseId,
            SubLot = e.SubLot,
            UnitOfMeasure = e.UnitOfMeasure
        }).ToList();

        return dtos;
    }
}