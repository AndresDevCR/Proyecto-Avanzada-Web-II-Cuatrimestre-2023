using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class LocationDalImpl : ILocationDAL
    {
        private readonly IGenericDal<Location> _locationRepository;

        public LocationDalImpl(PrograContext dbContext)
        {
            _locationRepository = new GenericRepository<Location>(dbContext);
        }

        public async Task Add(Location entity)
        {
            await _locationRepository.Add(entity);
        }

        public async Task Delete(Location entity)
        {
            await _locationRepository.Delete(entity);
        }

        public async Task<IEnumerable<Location>> Find(Expression<Func<Location, bool>> predicate)
        {
            return await _locationRepository.Find(predicate);
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await _locationRepository.GetAll();
        }

        public async Task<Location> GetById(int id)
        {
            return await _locationRepository.GetById(id);
        }

        public async Task Update(Location entity)
        {
            await _locationRepository.Update(entity);
        }
    }
}
