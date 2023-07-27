using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class UserDALImp : IUserDAL
    {
        private readonly PrograContext _prograContext;
        private UnidadDeTrabajo<User> unidad;
   

        public bool Add(User entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(_prograContext))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately.
                Console.WriteLine($"Error while adding user: {ex.Message}");
                return false;
            }
        }

        public void AddRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(_prograContext))
                {
                    return unidad.genericDAL.Find(predicate);
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately.
                Console.WriteLine($"Error while finding users: {ex.Message}");
                return Enumerable.Empty<User>();
            }
        }

        public User Get(int id)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(_prograContext))
                {
                    return unidad.genericDAL.Get(id);
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately.
                Console.WriteLine($"Error while getting user: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(_prograContext))
                {
                    return unidad.genericDAL.GetAll();
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately.
                Console.WriteLine($"Error while getting all users: {ex.Message}");
                return Enumerable.Empty<User>();
            }
        }

        public bool Remove(User entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(_prograContext))
                {
                    unidad.genericDAL.Remove(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately.
                Console.WriteLine($"Error while removing user: {ex.Message}");
                return false;
            }
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public User SingleOrDefault(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(_prograContext))
                {
                    unidad.genericDAL.Update(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately.
                Console.WriteLine($"Error while updating user: {ex.Message}");
                return false;
            }
        }
    }
}
