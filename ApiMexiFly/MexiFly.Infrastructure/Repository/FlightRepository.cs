using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class FlightRepository : IFlightRepository
{
    private readonly MexiflyDbContext _context;
    public FlightRepository(MexiflyDbContext context)
    {
        _context = context;
    }

    public async Task<TblFlight?> Create(TblFlight flight)
    {
        await _context.TblFlights.AddAsync(flight);
        await _context.SaveChangesAsync();

        return flight;
    }

    public async Task Delete(long flightId)
    {
        var entity = await _context.TblFlights.SingleOrDefaultAsync(c => c.FlightId == flightId);

        if (entity == null)
        {
            return;
        }

        _context.Set<TblFlight>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TblFlight?> Details(long flightId)
    {
        return await _context.TblFlights.SingleOrDefaultAsync(c => c.FlightId == flightId);
    }

    public async Task<List<TblFlight>> GetFlights()
    {
        var flights = await _context.TblFlights
            .Include(f => f.OriginAirport)          // Relación con aeropuerto de origen
            .Include(f => f.DestinationAirport)     // Relación con aeropuerto de destino
            .Include(f => f.TblRates)               // Relación con TblRates (tarifas)
                .ThenInclude(r => r.Category)       // Relación con Category dentro de TblRates
            .ToListAsync();

        return flights;
    }

    public async Task<TblFlight?> Udpate(TblFlight flight)
    {
        _context.Set<TblFlight>().Attach(flight);
        _context.Entry(flight).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return flight;
    }
}
