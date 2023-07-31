using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class ClientDalImpl : IClientDal
{
    private readonly IGenericDal<Client> _clientRepository;

    public ClientDalImpl(PrograContext dbContext)
    {
        _clientRepository = new GenericRepository<Client>(dbContext);
    }

    public async Task Add(Client entity)
    {
        await _clientRepository.Add(entity);
    }

    public async Task Delete(Client entity)
    {
        await _clientRepository.Delete(entity);
    }

    public async Task<IEnumerable<Client>> Find(Expression<Func<Client, bool>> predicate)
    {
        return await _clientRepository.Find(predicate);
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _clientRepository.GetAll();
    }

    public async Task<Client> GetById(int id)
    {
        return await _clientRepository.GetById(id);
    }

    public async Task Update(Client entity)
    {
        await _clientRepository.Update(entity);
    }
}