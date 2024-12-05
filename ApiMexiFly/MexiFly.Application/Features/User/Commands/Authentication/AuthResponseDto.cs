using System;

namespace MexiFly.Application.Features.User.Commands.Authentication;

public record AuthResponseDto(string Username, string Token, DateTime ExpiresIn, string TokenType, string RoleName);
