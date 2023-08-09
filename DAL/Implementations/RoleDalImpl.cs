using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class RoleDalImpl : IRoleDal
{
    private readonly IGenericDal<Role> _roleRepository;

    public RoleDalImpl(PrograContext dbContext)
    {
        _roleRepository = new GenericRepository<Role>(dbContext);
    }

    public async Task Add(Role entity)
    {
        await _roleRepository.Add(entity);
    }

    public async Task Delete(Role entity)
    {
        await _roleRepository.Delete(entity);
    }

    public async Task<IEnumerable<Role>> Find(Expression<Func<Role, bool>> predicate)
    {
        return await _roleRepository.Find(predicate);
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await _roleRepository.GetAll();
    }

    public async Task<Role> GetById(int id)
    {
        return await _roleRepository.GetById(id);
    }

    public async Task Update(Role entity)
    {
        await _roleRepository.Update(entity);
    }
}