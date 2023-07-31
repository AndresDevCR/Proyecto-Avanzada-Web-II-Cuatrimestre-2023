using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class InventoryDalImpl : IInventoryDAL
    {
        private readonly IGenericDal<Inventory> _inventoryRepository;

        public InventoryDalImpl(PrograContext dbContext)
        {
            _inventoryRepository = new GenericRepository<Inventory>(dbContext);
        }

        public async Task Add(Inventory entity)
        {
            await _inventoryRepository.Add(entity);
        }

        public async Task Delete(Inventory entity)
        {
            await _inventoryRepository.Delete(entity);
        }

        public async Task<IEnumerable<Inventory>> Find(Expression<Func<Inventory, bool>> predicate)
        {
            return await _inventoryRepository.Find(predicate);
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _inventoryRepository.GetAll();
        }

        public async Task<Inventory> GetById(int id)
        {
            return await _inventoryRepository.GetById(id);
        }

        public async Task Update(Inventory entity)
        {
            await _inventoryRepository.Update(entity);
        }
    }
}
