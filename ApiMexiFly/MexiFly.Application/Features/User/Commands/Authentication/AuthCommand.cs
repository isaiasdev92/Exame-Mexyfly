using System;
using MediatR;
using MexiFly.Transversal.Common;

namespace MexiFly.Application.Features.User.Commands.Authentication;

public class AuthCommand : IRequest<ResponseGeneral<AuthResponseDto>>
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
