using System;
using MediatR;
using MexiFly.Entities;
using MexiFly.Infrastructure.Interfaces;
using MexiFly.Transversal.Common;
using MexiFly.Transversal.ExceptionCustom;

namespace MexiFly.Application.Features.Ticket.Commands.BuyTicket;

public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, ResponseGeneral<BuyTicketResponseDto>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IRateRepository _rateRepository;
    public BuyTicketCommandHandler(ITicketRepository ticketRepository, IRateRepository rateRepository)
    {
        _ticketRepository = ticketRepository;
        _rateRepository = rateRepository;
    }
    public async Task<ResponseGeneral<BuyTicketResponseDto>> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
    {
        var categoryItem = await _rateRepository.FilterByFlightId(request.FlightId, request.CategoryId) ?? new TblRate();

        if (categoryItem.CategoryId == 0)
        {
            throw new BadRequestException("No se encontraron los datos");
        }

        var entity = new TblTicket(){
            ClientId = request.ClientId,
            TotalPrice = categoryItem.Price!,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        await _ticketRepository.Create(entity);

        return new ResponseGeneral<BuyTicketResponseDto>() {
            Data = new BuyTicketResponseDto() {
                TicketId = entity.TicketId,
            },
            Status = ResponseStatus.Success.ToString(),
        };
    }
}
