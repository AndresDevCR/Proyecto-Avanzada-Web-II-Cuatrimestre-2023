using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class PositionDalImpl : IPositionDAL
{
    private readonly IGenericDal<Position> _positionRepository;

    public PositionDalImpl(PrograContext dbContext)
    {
        _positionRepository = new GenericRepository<Position>(dbContext);
    }

    public async Task Add(Position entity)
    {
        await _positionRepository.Add(entity);
    }

    public async Task Delete(Position entity)
    {
        await _positionRepository.Delete(entity);
    }

    public async Task<IEnumerable<Position>> Find(Expression<Func<Position, bool>> predicate)
    {
        return await _positionRepository.Find(predicate);
    }

    public async Task<IEnumerable<Position>> GetAll()
    {
        return await _positionRepository.GetAll();
    }

    public async Task<Position> GetById(int id)
    {
        return await _positionRepository.GetById(id);
    }

    public async Task Update(Position entity)
    {
        await _positionRepository.Update(entity);
    }
}