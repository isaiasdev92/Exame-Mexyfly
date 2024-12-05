using System;
using MediatR;
using MexiFly.Transversal.Common;

namespace MexiFly.Application.Features.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<ResponseGeneral< CreateUserResponseDto>>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastNameP { get; set; } = string.Empty;
    public string LastNameM { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
