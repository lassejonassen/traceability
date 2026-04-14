using Traceability.Domain.ProductionEvents.DTOs;
using Traceability.Domain.ProductionEvents.Repositories;
using Traceability.Domain.ProductionEvents.Services;
using Traceability.SharedKernel;

namespace Traceability.Application.ProductionEvents.Commands;

public sealed record CreateProductionEventCommand(DTOs.CreateProductionEventDTO Dto) : IRequest<Result<Guid>>;

public sealed class CreateProductionEventCommandHandler(
    ICreateProductionEventService createProductionEventService,
    IProductionEventRepository productionEventRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider)
    : IRequestHandler<CreateProductionEventCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateProductionEventCommand request, CancellationToken cancellationToken)
    {
        var utcNow = dateTimeProvider.UtcNow;

        var data = MapToDomain(request.Dto);

        var productionEvent = await createProductionEventService.CreateAsync(data, utcNow, cancellationToken);

        if (productionEvent.IsFailure)
        {
            return Result.Failure<Guid>(productionEvent.Error);
        }

        productionEventRepository.Add(productionEvent.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(productionEvent.Value.Id);
    }

    private static ProductionEventCaptureDTO MapToDomain(DTOs.CreateProductionEventDTO dto)
    {
        return new()
        {
            Equipment = dto.Equipment,
            Material = dto.Material,
            ProductionEventType = dto.ProductionEventType,
            ProductionRequest = dto.ProductionRequest,
            Quantity = dto.Quantity,
            SegmentResponse = dto.SegmentResponse,
            UnitOfMeasure = dto.UnitOfMeasure,
            EventId = dto.EventId,
            Location = dto.Location,
            Lot = dto.Lot,
            SubLot = dto.SubLot,
            ProductionSchedule = dto.ProductionSchedule,
            SegmentRequirement = dto.SegmentRequirement,
            ProcessSegment = dto.ProcessSegment,
        };
    }
}