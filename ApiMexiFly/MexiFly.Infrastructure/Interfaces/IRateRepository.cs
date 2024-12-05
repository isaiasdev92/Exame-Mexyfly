using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface IRateRepository
{
    Task<TblRate?> Create(TblRate rate);
    Task<TblRate?> Udpate(TblRate rate);
    Task<TblRate?> Details(long rateId);
    Task<TblRate?> FilterByFlightId(long flightId, int categoryId);
    Task Delete(long rateId);
    Task<List<TblRate>> GetRates(int page, int pageSize);
}
