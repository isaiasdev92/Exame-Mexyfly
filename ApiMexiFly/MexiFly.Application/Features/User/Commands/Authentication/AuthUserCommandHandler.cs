using MediatR;
using MexiFly.Infrastructure.Interfaces;
using MexiFly.Transversal.Common;

namespace MexiFly.Application.Features.User.Commands.Authentication;

public class AuthUserCommandHandler : IRequestHandler<AuthCommand, ResponseGeneral<AuthResponseDto>>
{
    private readonly IUserRepository _userService;

    public AuthUserCommandHandler(IUserRepository userService)
    {
        _userService = userService;
    }
    
    public async Task<ResponseGeneral<AuthResponseDto>> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var response = await _userService.Authentication(request.Username, request.Password);
        
        return new ResponseGeneral<AuthResponseDto>() {};
    }
}
