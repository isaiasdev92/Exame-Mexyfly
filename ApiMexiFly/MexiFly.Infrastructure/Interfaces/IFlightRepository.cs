using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface IFlightRepository
{
    Task<TblFlight?> Create(TblFlight flight);
    Task<TblFlight?> Udpate(TblFlight flight);
    Task<TblFlight?> Details(long flightId);
    Task Delete(long flightId);
    Task<List<TblFlight>> GetFlights();
}
