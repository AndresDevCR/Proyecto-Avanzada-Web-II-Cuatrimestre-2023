using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UserDalImp : IUserDal
    {
        private readonly IDalGeneric<User> _userRepository;

        public UserDalImp(PrograContext dbContext)
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