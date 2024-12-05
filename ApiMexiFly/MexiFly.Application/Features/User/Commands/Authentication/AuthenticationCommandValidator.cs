using System;
using FluentValidation;

namespace MexiFly.Application.Features.User.Commands.Authentication;

public class AuthenticationCommandValidator : AbstractValidator<AuthCommand>
{
    public AuthenticationCommandValidator()
    {
        RuleFor(p => p.Username)
            .NotNull().WithMessage("El nombre de usuario es obligatorio")
            .NotEmpty().WithMessage("El nombre de usuario es obligatorio")
            .MaximumLength(50).WithMessage("El nombre no debe tener mas de 50 carácteres");

        RuleFor(p => p.Password)
            .NotNull().WithMessage("La descripción no debe ser null")
            .NotEmpty().WithMessage("La descripción no debe ser vacia")
            .MaximumLength(10).WithMessage("La descripción no debe tener mas de 20 carácteres");         
    }
}
