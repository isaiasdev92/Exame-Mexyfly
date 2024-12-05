using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class RateRepository : IRateRepository
{
        private readonly MexiflyDbContext _context;
    public RateRepository(MexiflyDbContext context)
    {
        _context = context;
    }

    public async Task<TblRate?> Create(TblRate rate)
    {
        await _context.TblRates.AddAsync(rate);
        await _context.SaveChangesAsync();

        return rate;
    }

    public async Task Delete(long rateId)
    {
        var entity = await _context.TblRates.SingleOrDefaultAsync(c => c.RateId == rateId);

        if (entity == null)
        {
            return;
        }

        _context.Set<TblRate>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TblRate?> Details(long rateId)
    {
        return await _context.TblRates.SingleOrDefaultAsync(c => c.RateId == rateId);
    }

    public async Task<TblRate?> FilterByFlightId(long flightId, int categoryId)
    {
        return await _context.TblRates.SingleOrDefaultAsync(c => c.FlightId == flightId && c.CategoryId == categoryId);
    }

    public  async Task<List<TblRate>> GetRates(int page, int pageSize)
    {
        var elements = await _context.TblRates
            .OrderBy(a => a.RateId) // Ordenar los elementos por un campo (opcional)
            .Skip((page - 1) * pageSize) // Saltar los elementos de las páginas anteriores
            .Take(pageSize) // Tomar los elementos de la página actual
            .ToListAsync(); // Ejecutar la consulta asíncronamente

        return elements;
    }

    public async Task<TblRate?> Udpate(TblRate rate)
    {
        _context.Set<TblRate>().Attach(rate);
        _context.Entry(rate).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return rate;
    }
}
