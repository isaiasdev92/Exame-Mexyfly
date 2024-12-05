using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface ISegmentRepository
{
    Task<TblSegment?> Create(TblSegment segment);
    Task<TblSegment?> Update(TblSegment segment);
    Task Delete(long segmentId);
    Task<TblSegment?> Details(long segmentId);
    Task<List<TblSegment>> GetSegments(int page, int pageSize);
}
