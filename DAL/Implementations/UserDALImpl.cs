using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class UserDalImpl : IUserDal
    {
        private readonly IGenericDal<User> _userRepository;

        public UserDalImpl(PrograContext dbContext)
        {
            _userRepository = new GenericRepository<User>(dbContext);
        }

        public async Task Add(User entity)
        {
            await _userRepository.Add(entity);
        }

        public async Task Delete(User entity)
        {
            await _userRepository.Delete(entity);
        }

        public async Task<IEnumerable<User>> Find(Expression<Func<User, bool>> predicate)
        {
            return await _userRepository.Find(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task Update(User entity)
        {
            await _userRepository.Update(entity);
        }
    }
}