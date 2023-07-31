using System.Linq.Expressions;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;

namespace DAL.Implementations;

public class CompanyDalImpl : ICompanyDal
{
    private readonly IGenericDal<Company> _companyRepository;

    public CompanyDalImpl(PrograContext dbContext)
    {
        _companyRepository = new GenericRepository<Company>(dbContext);
    }

    public async Task Add(Company entity)
    {
        await _companyRepository.Add(entity);
    }

    public async Task Delete(Company entity)
    {
        await _companyRepository.Delete(entity);
    }

    public async Task<IEnumerable<Company>> Find(Expression<Func<Company, bool>> predicate)
    {
        return await _companyRepository.Find(predicate);
    }

    public async Task<IEnumerable<Company>> GetAll()
    {
        return await _companyRepository.GetAll();
    }

    public async Task<Company> GetById(int id)
    {
        return await _companyRepository.GetById(id);
    }

    public async Task Update(Company entity)
    {
        await _companyRepository.Update(entity);
    }
}