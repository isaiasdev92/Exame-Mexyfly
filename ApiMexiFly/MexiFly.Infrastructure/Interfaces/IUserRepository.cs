using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<TblUser?> Authentication(string username, string password);
    Task<TblUser?> Create(TblUser user);
    Task<TblUser?> Udpate(TblUser user);
    Task<TblUser?> Details(long userId);
}
