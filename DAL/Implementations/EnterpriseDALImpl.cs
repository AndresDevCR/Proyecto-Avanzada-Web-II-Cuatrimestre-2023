using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class EnterpriseDALImpl : IEnterpriseDAL
    {
        private readonly IGenericDal<Enterprise> _enterpriseRepository;

        public EnterpriseDALImpl(PrograContext dbContext)
        {
            _enterpriseRepository = new GenericRepository<Enterprise>(dbContext);
        }

        public async Task Add(Enterprise entity)
        {
            await _enterpriseRepository.Add(entity);
        }

        public async Task Delete(Enterprise entity)
        {
            await _enterpriseRepository.Delete(entity);
        }

        public async Task<IEnumerable<Enterprise>> Find(Expression<Func<Enterprise, bool>> predicate)
        {
            return await _enterpriseRepository.Find(predicate);
        }

        public async Task<IEnumerable<Enterprise>> GetAll()
        {
            return await _enterpriseRepository.GetAll();
        }

        public async Task<Enterprise> GetById(int id)
        {
            return await _enterpriseRepository.GetById(id);
        }

        public async Task Update(Enterprise entity)
        {
            await _enterpriseRepository.Update(entity);
        }
    }
}