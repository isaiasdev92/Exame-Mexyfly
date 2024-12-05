using System;
using FluentValidation;

namespace MexiFly.Application.Features.Ticket.Commands.BuyTicket;

public class BuyTicketCommandValidator : AbstractValidator<BuyTicketCommand>
{

    public BuyTicketCommandValidator()
    {
        RuleFor(x => x.ClientId)
            .GreaterThan(0).WithMessage("El ID del cliente debe ser mayor que cero.")
            .NotNull().WithMessage("El ID del cliente es obligatorio.");

        // Validación de TotalPrice
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("El precio total debe ser mayor a cero.")
            .NotNull().WithMessage("El precio total es obligatorio.");
    }
}
