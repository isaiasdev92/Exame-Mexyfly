using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly MexiflyDbContext _context;
    public TicketRepository(MexiflyDbContext context)
    {
        _context = context;
    }
    public async Task<TblTicket?> Create(TblTicket ticket)
    {
        await _context.TblTickets.AddAsync(ticket);
        await _context.SaveChangesAsync();

        return ticket;
    }

    public async Task Delete(long ticketId)
    {
        var entity = await _context.TblTickets.SingleOrDefaultAsync(c => c.TicketId == ticketId);

        if (entity == null)
        {
            return;
        }

        _context.Set<TblTicket>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TblTicket?> Details(long ticketId)
    {
        return await _context.TblTickets.SingleOrDefaultAsync(c => c.TicketId == ticketId);
    }

    public async Task<List<TblTicket>> GetTickets(int page, int pageSize)
    {
        var elements = await _context.TblTickets
            .OrderBy(a => a.TicketId) // Ordenar los elementos por un campo (opcional)
            .Skip((page - 1) * pageSize) // Saltar los elementos de las páginas anteriores
            .Take(pageSize) // Tomar los elementos de la página actual
            .ToListAsync(); // Ejecutar la consulta asíncronamente

        return elements;
    }

    public async Task<TblTicket?> Udpate(TblTicket ticket)
    {
        _context.Set<TblTicket>().Attach(ticket);
        _context.Entry(ticket).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return ticket;
    }
}
