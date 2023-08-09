using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class ApplicationDalImpl : IApplicationDal
{
    private readonly IGenericDal<Application> _applicationRepository;

    public ApplicationDalImpl(PrograContext dbContext)
    {
        _applicationRepository = new GenericRepository<Application>(dbContext);
    }

    public async Task Add(Application entity)
    {
        await _applicationRepository.Add(entity);
    }

    public async Task Delete(Application entity)
    {
        await _applicationRepository.Delete(entity);
    }

    public async Task<IEnumerable<Application>> Find(Expression<Func<Application, bool>> predicate)
    {
        return await _applicationRepository.Find(predicate);
    }

    public async Task<IEnumerable<Application>> GetAll()
    {
        return await _applicationRepository.GetAll();
    }

    public async Task<Application> GetById(int id)
    {
        return await _applicationRepository.GetById(id);
    }

    public async Task Update(Application entity)
    {
        await _applicationRepository.Update(entity);
    }
}