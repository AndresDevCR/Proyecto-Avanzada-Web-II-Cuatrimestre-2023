using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class EmployeeDalImpl : IEmployeeDal
{
    private readonly IGenericDal<Employee> _employeeRepository;

    public EmployeeDalImpl(PrograContext dbContext)
    {
        _employeeRepository = new GenericRepository<Employee>(dbContext);
    }

    public async Task Add(Employee entity)
    {
        await _employeeRepository.Add(entity);
    }

    public async Task Delete(Employee entity)
    {
        await _employeeRepository.Delete(entity);
    }

    public async Task<IEnumerable<Employee>> Find(Expression<Func<Employee, bool>> predicate)
    {
        return await _employeeRepository.Find(predicate);
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await _employeeRepository.GetAll();
    }

    public async Task<Employee> GetById(int id)
    {
        return await _employeeRepository.GetById(id);
    }

    public async Task Update(Employee entity)
    {
        await _employeeRepository.Update(entity);
    }
}