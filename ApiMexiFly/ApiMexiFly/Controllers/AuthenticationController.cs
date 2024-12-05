using System.Net;
using System.Net.Mime;
using MediatR;
using MexiFly.Application.Features.Flight.Queries.List;
using MexiFly.Application.Features.User.Commands.Authentication;
using MexiFly.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MexiFly.Services.WebApi.Controllers;


[AllowAnonymous]
public class AuthenticationController : BaseAppController
{
    private readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost(Name = "Authentication")]    
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
    public async Task<ActionResult<ResponseGeneral<AuthResponseDto>>> Login([FromBody] AuthCommand command)
    {
        var result = await _mediator.Send(command);

        return Created(new Uri(Request.GetEncodedUrl()), result);
    }


}
