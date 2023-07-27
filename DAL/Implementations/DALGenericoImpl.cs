using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {
        protected readonly PrograContext Context;

        public DALGenericoImpl(PrograContext context)
        {
            Context = context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
               User user = (User)Convert.ChangeType(entity, typeof(User));
                Context.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Where(predicate).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TEntity Get(int id)
        {
            try
            {
               IEnumerable<TEntity> entity = (IEnumerable<TEntity>)Context.Set<TEntity>().Find(id);
                return (TEntity)entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
               User user = (User)Convert.ChangeType(Context.Set<TEntity>().ToList(), typeof(User));
                return (IEnumerable<TEntity>)user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Attach(entity);
                Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().SingleOrDefault(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
