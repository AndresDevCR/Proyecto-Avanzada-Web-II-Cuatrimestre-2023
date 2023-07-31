using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class HumanResourceDalImpl : IHumanResourceDAL
    {
        private readonly IGenericDal<HumanResource> _humanResourceRepository;

        public HumanResourceDalImpl(PrograContext dbContext)
        {
            _humanResourceRepository = new GenericRepository<HumanResource>(dbContext);
        }

        public async Task Add(HumanResource entity)
        {
            await _humanResourceRepository.Add(entity);
        }

        public async Task Delete(HumanResource entity)
        {
            await _humanResourceRepository.Delete(entity);
        }

        public async Task<IEnumerable<HumanResource>> Find(Expression<Func<HumanResource, bool>> predicate)
        {
            return await _humanResourceRepository.Find(predicate);
        }

        public async Task<IEnumerable<HumanResource>> GetAll()
        {
            return await _humanResourceRepository.GetAll();
        }

        public async Task<HumanResource> GetById(int id)
        {
            return await _humanResourceRepository.GetById(id);
        }

        public async Task Update(HumanResource entity)
        {
            await _humanResourceRepository.Update(entity);
        }
    }
}
