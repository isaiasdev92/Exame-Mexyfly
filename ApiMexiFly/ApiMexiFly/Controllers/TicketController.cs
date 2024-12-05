using System;
using System.Net;
using System.Net.Mime;
using MediatR;
using MexiFly.Application.Features.Ticket.Commands.BuyTicket;
using MexiFly.Transversal.Common;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MexiFly.Services.WebApi.Controllers;

public class TicketController : BaseAppController
{
    private readonly IMediator _mediator;
    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "Comprar ticket")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ResponseGeneral<BuyTicketResponseDto>>> Create([FromBody] BuyTicketCommand command)
    {
        var result = await _mediator.Send(command);

        return Created(new Uri(Request.GetEncodedUrl()), result);
    }
}
