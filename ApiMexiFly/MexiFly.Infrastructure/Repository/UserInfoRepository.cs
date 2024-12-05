using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class UserInfoRepository : IUserInfoRepository
{
    private readonly MexiflyDbContext _context;
    public UserInfoRepository(MexiflyDbContext context)
    {
        _context = context;
    }

    public async Task<TblUserInfo?> Create(TblUserInfo userInfo)
    {
        await _context.TblUserInfos.AddAsync(userInfo);
        await _context.SaveChangesAsync();

        return userInfo;
    }

    public async Task Delete(long userInfoId)
    {
        var entity = await _context.TblUserInfos.SingleOrDefaultAsync(c => c.UserInfoId == userInfoId);

        if (entity == null)
        {
            return;
        }

        _context.Set<TblUserInfo>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TblUserInfo?> Details(long userInfoId)
    {
        return await _context.TblUserInfos.SingleOrDefaultAsync(c => c.UserInfoId == userInfoId);
    }

    public async Task<List<TblUserInfo>> GetUsers(int page, int pageSize)
    {
        var elements = await _context.TblUserInfos
            .OrderBy(a => a.FirstName) // Ordenar los elementos por un campo (opcional)
            .Skip((page - 1) * pageSize) // Saltar los elementos de las páginas anteriores
            .Take(pageSize) // Tomar los elementos de la página actual
            .ToListAsync(); // Ejecutar la consulta asíncronamente

        return elements;
    }

    public async Task<TblUserInfo?> Update(TblUserInfo userInfo)
    {
        _context.Set<TblUserInfo>().Attach(userInfo);
        _context.Entry(userInfo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return userInfo;
    }
}
