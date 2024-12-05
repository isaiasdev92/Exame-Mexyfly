using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class AirportRepository : IAirportRepository
{
    private readonly MexiflyDbContext _context;
    public AirportRepository(MexiflyDbContext context)
    {
        _context = context;
    }

    public async Task<TblAirport?> Create(TblAirport airport)
    {
        await _context.TblAirports.AddAsync(airport);
        await _context.SaveChangesAsync();

        return airport;
    }

    public async Task<TblAirport?> Details(string airportId)
    {
        return await _context.TblAirports.SingleOrDefaultAsync(a => a.AirportId == airportId);

    }

    public async Task<List<TblAirport>> GetAirports(int page, int pageSize)
    {
        var paginatedAirports = await _context.TblAirports
            .OrderBy(a => a.NameAirport) // Ordenar los elementos por un campo (opcional)
            .Skip((page - 1) * pageSize) // Saltar los elementos de las páginas anteriores
            .Take(pageSize) // Tomar los elementos de la página actual
            .ToListAsync(); // Ejecutar la consulta asíncronamente

        return paginatedAirports;
    }

    public async Task<TblAirport?> Update(TblAirport airport)
    {
        _context.Set<TblAirport>().Attach(airport);
        _context.Entry(airport).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return airport;
    }
}
