using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class ClientRepository : IClientRepository
{
    private readonly MexiflyDbContext _context;
    public ClientRepository(MexiflyDbContext context)
    {
        _context = context;
    }
    public async Task<TblClient?> Create(TblClient client)
    {
        await _context.TblClients.AddAsync(client);
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task Delete(long clientId)
    {
        var entity = await _context.TblClients.SingleOrDefaultAsync(c => c.ClientId == clientId);

        if (entity == null)
        {
            return;
        }

        _context.Set<TblClient>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TblClient?> Details(long clientId)
    {
        return await _context.TblClients.SingleOrDefaultAsync(c => c.ClientId == clientId);

    }

    public async Task<List<TblClient>> GetClients(int page, int pageSize)
    {
        var elements = await _context.TblClients
            .OrderBy(a => a.FirstName) // Ordenar los elementos por un campo (opcional)
            .Skip((page - 1) * pageSize) // Saltar los elementos de las páginas anteriores
            .Take(pageSize) // Tomar los elementos de la página actual
            .ToListAsync(); // Ejecutar la consulta asíncronamente

        return elements;
    }

    public async Task<TblClient?> Update(TblClient client)
    {
        _context.Set<TblClient>().Attach(client);
        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return client;
    }
}
