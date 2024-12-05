using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly MexiflyDbContext _context;
    public CategoryRepository(MexiflyDbContext context)
    {
        _context = context;
    }
    public async Task<TblCategory?> Create(TblCategory category)
    {
        await _context.TblCategories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<bool?> Delete(int categoryId)
    {
        var entity = await _context.TblCategories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

        if (entity == null)
        {
            return false;
        }

        _context.Set<TblCategory>().Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<TblCategory?> Details(int categoryId)
    {
        return await _context.TblCategories.SingleOrDefaultAsync(c => c.CategoryId == categoryId);
    }

    public async Task<List<TblCategory>> GetCategories()
    {
        return await _context.TblCategories.ToListAsync();
    }

    public async Task<TblCategory?> Udpate(TblCategory category)
    {
        _context.Set<TblCategory>().Attach(category);
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }
}
