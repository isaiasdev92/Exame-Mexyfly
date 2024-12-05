using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface ICategoryRepository
{
    Task<TblCategory?> Create(TblCategory category);
    Task<TblCategory?> Udpate(TblCategory category);
    Task<TblCategory?> Details(int categoryId);
    Task<bool?> Delete(int categoryId);
    Task<List<TblCategory>> GetCategories();
}
