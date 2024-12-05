using System.Security.Cryptography;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using MexiFly.Application.Utils;
using MexiFly.Entities;
using MexiFly.Infrastructure.Interfaces;
using MexiFly.Transversal.Common;
using MexiFly.Transversal.ExceptionCustom;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;

namespace MexiFly.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseGeneral<CreateUserResponseDto>>
{
    private readonly IUserRepository _userService;
    private readonly IClientRepository _clientService;

    public CreateUserCommandHandler(IUserRepository userService, IClientRepository clientService)
    {
        _userService = userService;
        _clientService = clientService;
    }

    public async Task<ResponseGeneral<CreateUserResponseDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        TblUser user = new TblUser()
        {
            PasswordHash = new GeneratePasswordHash().Generate("12345678"),
            CreatedAt = DateTime.Now,
            CreatedBy = null,
            UpdatedBy = null,
            IsActive = true,
            RoleUser = RoleUser.Client.ToString(),
            UpdatedAt = DateTime.Now,
            Username = $"User{new Random().Next( int.MinValue, int.MaxValue )}",
        };

        var responseUser = await _userService.Create(user);


        if (responseUser == null)
        {
            throw new BadRequestException("No se pudo crear el usuario");
        }

        TblClient tblClient = new TblClient()
        {
            CreatedAt = DateTime.Now,
            CreatedBy = null,
            UpdatedBy = null,
            Email = request.Email,
            FirstName = request.FirstName,
            LastNameM = request.LastNameM,
            LastNameP = request.LastNameP,
            PhoneNumber = request.PhoneNumber,
            RegistrationDate = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserId = user.UserId,
        };

        var clientResponse = await _clientService.Create(tblClient);

        if (clientResponse == null)
        {
            throw new BadRequestException("No se pudo crear el usuario");
        }

        return new ResponseGeneral<CreateUserResponseDto>()
        {
            Data = new(responseUser.UserId, clientResponse.ClientId, request.FirstName, request.LastNameP, request.LastNameM, request.Email),
            Message = "success",
            Status = ResponseStatus.Success.ToString(),
        };
    }
}
