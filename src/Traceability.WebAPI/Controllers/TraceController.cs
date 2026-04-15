using Microsoft.AspNetCore.Mvc;
using Traceability.Application.ProductionEvents.Queries;

namespace Traceability.WebAPI.Controllers;

[Route("api/traces")]
public class TraceController : BaseController
{
    [HttpGet("tree/{productionRequestId:guid}")]
    public async Task<IActionResult> GetTree([FromRoute] Guid productionRequestId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetProductionEventTraceQuery(productionRequestId), cancellationToken);

        return Ok(result);
    }

    [HttpGet("{productionRequestId:guid}")]
    public async Task<IActionResult> GetAll([FromRoute] Guid productionRequestId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetProductionEventsByProductionRequestIdQuery(productionRequestId), cancellationToken);

        return Ok(result);
    }
}
