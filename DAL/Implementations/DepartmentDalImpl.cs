using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class DepartmentDalImpl : IDepartmentDal
{
    private readonly IGenericDal<Department> _departmentRepository;

    public DepartmentDalImpl(PrograContext dbContext)
    {
        _departmentRepository = new GenericRepository<Department>(dbContext);
    }

    public async Task Add(Department entity)
    {
        await _departmentRepository.Add(entity);
    }

    public async Task Delete(Department entity)
    {
        await _departmentRepository.Delete(entity);
    }

    public async Task<IEnumerable<Department>> Find(Expression<Func<Department, bool>> predicate)
    {
        return await _departmentRepository.Find(predicate);
    }

    public async Task<IEnumerable<Department>> GetAll()
    {
        return await _departmentRepository.GetAll();
    }

    public async Task<Department> GetById(int id)
    {
        return await _departmentRepository.GetById(id);
    }

    public async Task Update(Department entity)
    {
        await _departmentRepository.Update(entity);
    }
}