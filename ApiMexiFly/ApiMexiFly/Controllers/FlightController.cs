using System;
using System.Net;
using System.Net.Mime;
using MediatR;
using MexiFly.Application.Features.Flight.Queries.List;
using MexiFly.Transversal.Common;
using Microsoft.AspNetCore.Mvc;

namespace MexiFly.Services.WebApi.Controllers;

public class FlightController : BaseAppController
{
    private readonly IMediator _mediator;
    public FlightController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet(Name = "Obtiene todos los vuelos")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ResponseGeneral<FlightListDto>>> GetAll()
    {
        var areaComandlist = new GetFlightlistQuery();
        var result = await _mediator.Send(areaComandlist);

        return Ok(result);
    }
}
