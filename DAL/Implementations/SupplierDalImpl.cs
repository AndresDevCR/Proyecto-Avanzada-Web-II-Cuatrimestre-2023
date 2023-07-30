using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class SupplierDalImpl: ISupplierDal
{
    private readonly IGenericDal<Supplier> _supplierRepository ;

    public SupplierDalImpl(PrograContext dbContext)
    {
        _supplierRepository = new GenericRepository<Supplier>(dbContext);
    }

    public async Task Add(Supplier entity)
    {
        await _supplierRepository.Add(entity);
    }

    public async Task Delete(Supplier entity)
    {
        await _supplierRepository.Delete(entity);
    }

    public async Task<IEnumerable<Supplier>> Find(Expression<Func<Supplier, bool>> predicate)
    {
        return await _supplierRepository.Find(predicate);
    }

    public async Task<IEnumerable<Supplier>> GetAll()
    {
        return await _supplierRepository.GetAll();
    }

    public async Task<Supplier> GetById(int id)
    {
        return await _supplierRepository.GetById(id);
    }

    public async Task Update(Supplier entity)
    {
        await _supplierRepository.Update(entity);
    }
}