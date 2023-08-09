using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class QuotationDalImpl:  IQuotationDal
{
    private readonly IGenericDal<Quotation> _quotationRepository ;

    public QuotationDalImpl(PrograContext dbContext)
    {
        _quotationRepository = new GenericRepository<Quotation>(dbContext);
    }

    public async Task Add(Quotation entity)
    {
        await _quotationRepository.Add(entity);
    }

    public async Task Delete(Quotation entity)
    {
        await _quotationRepository.Delete(entity);
    }

    public async Task<IEnumerable<Quotation>> Find(Expression<Func<Quotation, bool>> predicate)
    {
        return await _quotationRepository.Find(predicate);
    }

    public async Task<IEnumerable<Quotation>> GetAll()
    {
        return await _quotationRepository.GetAll();
    }

    public async Task<Quotation> GetById(int id)
    {
        return await _quotationRepository.GetById(id);
    }

    public async Task Update(Quotation entity)
    {
        await _quotationRepository.Update(entity);
    }
}