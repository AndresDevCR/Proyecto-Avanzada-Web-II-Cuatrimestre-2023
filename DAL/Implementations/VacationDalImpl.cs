using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class VacationDalImpl:  IVacationDal
{
    private readonly IGenericDal<Vacation> _vacationRepository ;

    public VacationDalImpl(PrograContext dbContext)
    {
        _vacationRepository = new GenericRepository<Vacation>(dbContext);
    }

    public async Task Add(Vacation entity)
    {
        await _vacationRepository.Add(entity);
    }

    public async Task Delete(Vacation entity)
    {
        await _vacationRepository.Delete(entity);
    }

    public async Task<IEnumerable<Vacation>> Find(Expression<Func<Vacation, bool>> predicate)
    {
        return await _vacationRepository.Find(predicate);
    }

    public async Task<IEnumerable<Vacation>> GetAll()
    {
        return await _vacationRepository.GetAll();
    }

    public async Task<Vacation> GetById(int id)
    {
        return await _vacationRepository.GetById(id);
    }

    public async Task Update(Vacation entity)
    {
        await _vacationRepository.Update(entity);
    }
}