using Traceability.Domain.Equipments.Entities;
using Traceability.Domain.Equipments.Repositories;
using Traceability.Domain.Locations.Entities;
using Traceability.Domain.Locations.Repositories;
using Traceability.Domain.Materials.Entities;
using Traceability.Domain.Materials.Repositories;
using Traceability.Domain.ProcessSegments.Entities;
using Traceability.Domain.ProcessSegments.Repositories;
using Traceability.Domain.ProductionEvents.DTOs;
using Traceability.Domain.ProductionEvents.Entities;
using Traceability.Domain.ProductionRequests.Entities;
using Traceability.Domain.ProductionRequests.Repositories;
using Traceability.Domain.ProductionSchedules.Entities;
using Traceability.Domain.ProductionSchedules.Repositories;
using Traceability.Domain.SegmentRequirements.Entities;
using Traceability.Domain.SegmentRequirements.Repositories;
using Traceability.Domain.SegmentResponses.Entities;
using Traceability.Domain.SegmentResponses.Repositories;

namespace Traceability.Domain.ProductionEvents.Services;

public class CreateProductionEventService(
    IProductionScheduleRepository productionScheduleRepository,
    IProductionRequestRepository productionRequestRepository,
    ISegmentRequirementRepository segmentRequirementRepository,
    IProcessSegmentRepository processSegmentRepository,
    ISegmentResponseRepository segmentResponseRepository,
    IMaterialRepository materialRepository,
    IEquipmentRepository equipmentRepository,
    ILocationRepository locationRepository)
    : ICreateProductionEventService
{
    public async Task<Result<ProductionEvent>> CreateAsync(ProductionEventCaptureDTO data, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        var productionSchedule = await GetOrCreateProductionSchedule(data.ProductionSchedule, utcNow, cancellationToken);
        var productionRequest = await GetOrCreateProductionRequest(data.ProductionRequest, utcNow, cancellationToken);
        var processSegment = await GetOrCreateProcessSegment(data.ProcessSegment, utcNow, cancellationToken);
        var segmentRequirement = await GetOrCreateSegmentRequirement(data.ProductionRequest, utcNow, cancellationToken);
        var segmentResponse = await GetOrCreateSegmentResponse(data.SegmentResponse, processSegment.Id, utcNow, cancellationToken);
        var material = await GetOrCreateMaterial(data.Material, utcNow, cancellationToken);
        var location = await GetOrCreateLocation(data.Location, utcNow, cancellationToken);
        var equipment = await GetOrCreateEquipment(data.Equipment, utcNow, cancellationToken);

        var dto = new CreateProductionEventDTO
        {
            Comment = data.Comment ?? string.Empty,
            Equipment = equipment.Id,
            EventId = data.EventId ?? string.Empty,
            Location = location.Id,
            Lot = data.Lot ?? string.Empty,
            Material = material.Id,
            ProductionEventType = data.ProductionEventType,
            ProductionRequest = productionRequest.Id,
            ProductionSchedule = productionSchedule.Id,
            Quantity = data.Quantity,
            SegmentRequirement = segmentRequirement.Id,
            SegmentResponse = segmentResponse.Id,
            SubLot = data.SubLot ?? string.Empty,
            UnitOfMeasure =data.UnitOfMeasure,
        };

        var productionEvent = ProductionEvent.Create(dto, utcNow);

        if (productionEvent.IsFailure)
        {
            return Result.Failure<ProductionEvent>(productionEvent.Error);
        }

        return productionEvent;
    }

    private async Task<ProductionSchedule> GetOrCreateProductionSchedule(string? scheduleId, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(scheduleId))
        {
            var emptyEntity = ProductionSchedule.Create(string.Empty, utcNow);
            productionScheduleRepository.Add(emptyEntity.Value);
            return emptyEntity.Value;
        }

        var entity = await productionScheduleRepository.GetAsync(scheduleId!, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = ProductionSchedule.Create(scheduleId, utcNow);
        productionScheduleRepository.Add(newEntity.Value);

        return newEntity.Value;
    }

    private async Task<ProductionRequest> GetOrCreateProductionRequest(string requestId, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        var entity = await productionRequestRepository.GetAsync(requestId!, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = ProductionRequest.Create(requestId, utcNow);
        productionRequestRepository.Add(newEntity.Value);

        return newEntity.Value;
    }

    private async Task<SegmentRequirement> GetOrCreateSegmentRequirement(string requirementId, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        var entity = await segmentRequirementRepository.GetAsync(requirementId!, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = SegmentRequirement.Create(requirementId, utcNow);
        segmentRequirementRepository.Add(newEntity.Value);

        return newEntity.Value;
    }

    private async Task<ProcessSegment> GetOrCreateProcessSegment(string name, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        var entity = await processSegmentRepository.GetAsync(name!, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = ProcessSegment.Create(name, utcNow);
        processSegmentRepository.Add(newEntity.Value);

        return newEntity.Value;
    }

    private async Task<SegmentResponse> GetOrCreateSegmentResponse(string responseId, Guid processSegmentId, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        var entity = await segmentResponseRepository.GetAsync(responseId!, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = SegmentResponse.Create(responseId, processSegmentId, utcNow);
        segmentResponseRepository.Add(newEntity.Value);

        return newEntity.Value;
    }

    private async Task<Material> GetOrCreateMaterial(string name, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        var entity = await materialRepository.GetAsync(name, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = Material.Create(name, utcNow);
        materialRepository.Add(newEntity.Value);

        return newEntity.Value;
    }

    private async Task<Location> GetOrCreateLocation(string? name, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            var emptyEntity = Location.Create(string.Empty, utcNow);
            locationRepository.Add(emptyEntity.Value);
            return emptyEntity.Value;
        }

        var entity = await locationRepository.GetAsync(name, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = Location.Create(name, utcNow);
        locationRepository.Add(newEntity.Value);

        return newEntity.Value;
    }

    private async Task<Equipment> GetOrCreateEquipment(string name, DateTimeOffset utcNow, CancellationToken cancellationToken)
    {
        var entity = await equipmentRepository.GetAsync(name, cancellationToken);
        if (entity is not null)
        {
            return entity;
        }

        var newEntity = Equipment.Create(name, utcNow);
        equipmentRepository.Add(newEntity.Value);

        return newEntity.Value;
    }
}
