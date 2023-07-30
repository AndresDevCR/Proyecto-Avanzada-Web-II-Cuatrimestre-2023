using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class RoleHasPermissionDalImpl: IRoleHasPermissionDal
{
    private readonly IGenericDal<RoleHasPermission> _roleHasPermissionRepository ;

    public RoleHasPermissionDalImpl(PrograContext dbContext)
    {
        _roleHasPermissionRepository = new GenericRepository<RoleHasPermission>(dbContext);
    }

    public async Task Add(RoleHasPermission entity)
    {
        await _roleHasPermissionRepository.Add(entity);
    }

    public async Task Delete(RoleHasPermission entity)
    {
        await _roleHasPermissionRepository .Delete(entity);
    }

    public async Task<IEnumerable<RoleHasPermission>> Find(Expression<Func<RoleHasPermission, bool>> predicate)
    {
        return await _roleHasPermissionRepository.Find(predicate);
    }

    public async Task<IEnumerable<RoleHasPermission>> GetAll()
    {
        return await _roleHasPermissionRepository.GetAll();
    }

    public async Task<RoleHasPermission> GetById(int id)
    {
        return await _roleHasPermissionRepository.GetById(id);
    }

    public async Task Update(RoleHasPermission entity)
    {
        await _roleHasPermissionRepository.Update(entity);
    }
}