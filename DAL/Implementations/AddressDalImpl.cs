using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class AddressDalImpl : IAddressDal
{
    private readonly IGenericDal<Address> _addressRepository;

    public AddressDalImpl(PrograContext dbContext)
    {
        _addressRepository = new GenericRepository<Address>(dbContext);
    }

    public async Task Add(Address entity)
    {
        await _addressRepository.Add(entity);
    }

    public async Task Delete(Address entity)
    {
        await _addressRepository.Delete(entity);
    }

    public async Task<IEnumerable<Address>> Find(Expression<Func<Address, bool>> predicate)
    {
        return await _addressRepository.Find(predicate);
    }

    public async Task<IEnumerable<Address>> GetAll()
    {
        return await _addressRepository.GetAll();
    }

    public async Task<Address> GetById(int id)
    {
        return await _addressRepository.GetById(id);
    }

    public async Task Update(Address entity)
    {
        await _addressRepository.Update(entity);
    }
}