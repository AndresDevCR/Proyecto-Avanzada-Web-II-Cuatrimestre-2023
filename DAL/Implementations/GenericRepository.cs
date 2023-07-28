using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        private readonly PrograContext _prograContext;

        public GenericRepository(PrograContext prograContext)
        {
            _prograContext = prograContext;
        }

        public async Task Add(TEntity entity)
        {
            await _prograContext.Set<TEntity>().AddAsync(entity);
            await _prograContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _prograContext.Set<TEntity>().Remove(entity);
            await _prograContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _prograContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _prograContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _prograContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            // Update the properties of the entity
            _prograContext.Entry(entity).State = EntityState.Modified;

            // Save the changes
            await _prograContext.SaveChangesAsync();
        }
    }
}