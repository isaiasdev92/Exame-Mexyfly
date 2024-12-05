using System;
using FluentValidation;

namespace MexiFly.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{

    public CreateUserCommandValidator()
    {
        // RuleFor(p => p.Username)
        // .NotNull().WithMessage("El nombre de usuario es obligatorio.")
        // .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
        // .MaximumLength(50).WithMessage("El nombre de usuario no debe tener más de 50 caracteres.");

        // RuleFor(p => p.Password)
        //     .NotNull().WithMessage("La contraseña es obligatoria.")
        //     .NotEmpty().WithMessage("La contraseña es obligatoria.")
        //     .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.");

        RuleFor(p => p.FirstName)
            .NotNull().WithMessage("El nombre es obligatorio.")
            .NotEmpty().WithMessage("El nombre es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre no debe tener más de 100 caracteres.");

        RuleFor(p => p.LastNameP)
            .NotNull().WithMessage("El apellido paterno es obligatorio.")
            .NotEmpty().WithMessage("El apellido paterno es obligatorio.")
            .MaximumLength(100).WithMessage("El apellido paterno no debe tener más de 100 caracteres.");

        RuleFor(p => p.LastNameM)
            .MaximumLength(100).WithMessage("El apellido materno no debe tener más de 100 caracteres.");

        RuleFor(p => p.Email)
            .NotNull().WithMessage("El correo electrónico es obligatorio.")
            .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
            .EmailAddress().WithMessage("El correo electrónico no tiene un formato válido.")
            .MaximumLength(100).WithMessage("El correo electrónico no debe tener más de 100 caracteres.");

        RuleFor(p => p.PhoneNumber)
            .Matches(@"^\d{10,15}$").WithMessage("El número de teléfono debe contener entre 10 y 15 dígitos.")
            .When(p => !string.IsNullOrEmpty(p.PhoneNumber));            
    }

}
