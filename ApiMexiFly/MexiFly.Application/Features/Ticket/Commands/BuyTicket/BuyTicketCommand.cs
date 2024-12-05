using System;
using MediatR;
using MexiFly.Transversal.Common;

namespace MexiFly.Application.Features.Ticket.Commands.BuyTicket;

public class BuyTicketCommand : IRequest<ResponseGeneral<BuyTicketResponseDto>>
{
    public long ClientId { get; set; }

    public int CategoryId { get; set; }

    public long FlightId { get; set; }
}
