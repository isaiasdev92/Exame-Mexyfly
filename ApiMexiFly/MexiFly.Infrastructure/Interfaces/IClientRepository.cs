using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface IClientRepository
{
    Task<TblClient?> Create(TblClient client);
    Task<TblClient?> Update(TblClient client);
    Task Delete(long clientId);
    Task<TblClient?> Details(long clientId);
    Task<List<TblClient>> GetClients(int page, int pageSize);
}
