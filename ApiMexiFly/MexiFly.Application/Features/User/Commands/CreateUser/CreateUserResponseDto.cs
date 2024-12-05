using System;

namespace MexiFly.Application.Features.User.Commands.CreateUser;

public record CreateUserResponseDto (long UserId, long ClientId, string FirstName, string LastNameP, string LastNameM, string Email);
