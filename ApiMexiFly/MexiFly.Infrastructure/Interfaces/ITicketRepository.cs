using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface ITicketRepository
{
    Task<TblTicket?> Create(TblTicket ticket);
    Task<TblTicket?> Udpate(TblTicket ticket);
    Task<TblTicket?> Details(long ticketId);
    Task Delete(long ticketId);
    Task<List<TblTicket>> GetTickets(int page, int pageSize);
}
