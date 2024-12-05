using System;
using MexiFly.Entities;
using MexiFly.Infrastructure.Data;
using MexiFly.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Repository;

public class SegmentRepository : ISegmentRepository
{
    private readonly MexiflyDbContext _context;
    public SegmentRepository(MexiflyDbContext context)
    {
        _context = context;
    }


    public async Task<TblSegment?> Create(TblSegment segment)
    {
        await _context.TblSegments.AddAsync(segment);
        await _context.SaveChangesAsync();

        return segment;
    }

    public async Task Delete(long segmentId)
    {
        var entity = await _context.TblSegments.SingleOrDefaultAsync(c => c.SegmentId == segmentId);

        if (entity == null)
        {
            return;
        }

        _context.Set<TblSegment>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TblSegment?> Details(long segmentId)
    {
        return await _context.TblSegments.SingleOrDefaultAsync(c => c.SegmentId == segmentId);
    }

    public async Task<List<TblSegment>> GetSegments(int page, int pageSize)
    {
        var elements = await _context.TblSegments
            .OrderBy(a => a.SegmentId) // Ordenar los elementos por un campo (opcional)
            .Skip((page - 1) * pageSize) // Saltar los elementos de las páginas anteriores
            .Take(pageSize) // Tomar los elementos de la página actual
            .ToListAsync(); // Ejecutar la consulta asíncronamente

        return elements;
    }

    public async Task<TblSegment?> Update(TblSegment segment)
    {
        _context.Set<TblSegment>().Attach(segment);
        _context.Entry(segment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return segment;
    }
}
