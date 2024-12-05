using System;

namespace WebMexiFly.Pages.Flights.List.ResponseApp;

public record CreateUserResponseDto (long UserId, long ClientId, string FirstName, string LastNameP, string LastNameM, string Email);
