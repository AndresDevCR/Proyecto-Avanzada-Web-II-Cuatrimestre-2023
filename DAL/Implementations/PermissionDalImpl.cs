using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class PermissionDalImpl : IPermissionDAL
{
    private readonly IGenericDal<Permission> _permissionRepository;

    public PermissionDalImpl(PrograContext dbContext)
    {
        _permissionRepository = new GenericRepository<Permission>(dbContext);
    }

    public async Task Add(Permission entity)
    {
        await _permissionRepository.Add(entity);
    }

    public async Task Delete(Permission entity)
    {
        await _permissionRepository.Delete(entity);
    }

    public async Task<IEnumerable<Permission>> Find(Expression<Func<Permission, bool>> predicate)
    {
        return await _permissionRepository.Find(predicate);
    }

    public async Task<IEnumerable<Permission>> GetAll()
    {
        return await _permissionRepository.GetAll();
    }

    public async Task<Permission> GetById(int id)
    {
        return await _permissionRepository.GetById(id);
    }

    public async Task Update(Permission entity)
    {
        await _permissionRepository.Update(entity);
    }
}