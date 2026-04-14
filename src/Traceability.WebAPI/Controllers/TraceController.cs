using Microsoft.AspNetCore.Mvc;
using Traceability.Application.ProductionEvents.Queries;

namespace Traceability.WebAPI.Controllers;

[Route("api/traces")]
public class TraceController : BaseController
{
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [HttpGet("{productionRequestId}")]
    public async Task<IActionResult> Post([FromRoute] string productionRequestId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetProductionEventTraceQuery(productionRequestId), cancellationToken);

        return Ok(result);
    }
}
