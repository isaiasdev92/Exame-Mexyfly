using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface IAirportRepository
{
    Task<TblAirport?> Create(TblAirport airport);
    Task<TblAirport?> Update(TblAirport airport);
    Task<TblAirport?> Details(string airportId);
    Task<List<TblAirport>> GetAirports(int page, int pageSize);

}
