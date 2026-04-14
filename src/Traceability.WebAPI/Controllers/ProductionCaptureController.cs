
using Microsoft.AspNetCore.Mvc;
using Traceability.Application.ProductionEvents.Commands;
using Traceability.Application.ProductionEvents.DTOs;
using WebAPI.Contracts;

namespace Traceability.WebAPI.Controllers;

[Route("api/capture")]
public class ProductionCaptureController : BaseController
{
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CaptureProductionEventRequest request, CancellationToken cancellationToken)
    {
        var dto = new CreateProductionEventDTO
        {
            Equipment = request.Equipment,
            Material = request.Material,
            ProcessSegment = request.ProcessSegment,
            ProductionEventType = request.ProductionEventType,
            ProductionRequest  = request.ProductionRequest,
            Quantity = request.Quantity,
            SegmentResponse = request.SegmentResponse,
            UnitOfMeasure = request.UnitOfMeasure,
            EventId = request.EventId,
            Location = request.Location,
            Lot = request.Lot,
            SubLot = request.SubLot,
            ProductionSchedule = request.ProductionSchedule,
            SegmentRequirement = request.SegmentRequirement,
        };

        var result = await Mediator.Send(new CreateProductionEventCommand(dto), cancellationToken);

        return Ok();
    }
}
