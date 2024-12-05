using System;
using MexiFly.Entities;

namespace MexiFly.Infrastructure.Interfaces;

public interface IUserInfoRepository
{
    Task<TblUserInfo?> Create(TblUserInfo userInfo);
    Task<TblUserInfo?> Update(TblUserInfo userInfo);
    Task Delete(long ClientId);
    Task<TblUserInfo?> Details(long userInfoId);
    Task<List<TblUserInfo>> GetUsers(int page, int pageSize);
}
