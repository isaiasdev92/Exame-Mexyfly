using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    public readonly MexiflyDbContext _context;

    public UserRepository(MexiflyDbContext context)
    {
        _context = context;
    }

    public async Task<TblUser?> Authentication(string username, string password)
    {
        return await _context.TblUsers.SingleOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
    }

    public async Task<TblUser?> Create(TblUser user)
    {
        await _context.TblUsers.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<TblUser?> Details(long userId)
    {
        return await _context.TblUsers.SingleOrDefaultAsync(u => u.UserId == u.UserId); 
    }

    public async Task<TblUser?> Udpate(TblUser user)
    {
        _context.Set<TblUser>().Attach(user);
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }
}
