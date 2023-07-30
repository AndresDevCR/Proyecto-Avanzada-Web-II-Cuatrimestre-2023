using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class UserHasApplicationDalImpl: IUserHasApplicationDal
{
    private readonly IGenericDal<UserHasApplication> _userHasApplicationRepository ;

    public UserHasApplicationDalImpl(PrograContext dbContext)
    {
        _userHasApplicationRepository = new GenericRepository<UserHasApplication>(dbContext);
    }

    public async Task Add(UserHasApplication entity)
    {
        await _userHasApplicationRepository.Add(entity);
    }

    public async Task Delete(UserHasApplication entity)
    {
        await _userHasApplicationRepository .Delete(entity);
    }

    public async Task<IEnumerable<UserHasApplication>> Find(Expression<Func<UserHasApplication, bool>> predicate)
    {
        return await _userHasApplicationRepository.Find(predicate);
    }

    public async Task<IEnumerable<UserHasApplication>> GetAll()
    {
        return await _userHasApplicationRepository.GetAll();
    }

    public async Task<UserHasApplication> GetById(int id)
    {
        return await _userHasApplicationRepository.GetById(id);
    }

    public async Task Update(UserHasApplication entity)
    {
        await _userHasApplicationRepository.Update(entity);
    }
}