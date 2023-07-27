using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class RoleDALImpl : IRoleDAL
    {
        private PrograContext _prograContext;
        private UnidadDeTrabajo<Role> unidad;
        public bool Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            IEnumerable<Role> role = null;
            using (unidad = new UnidadDeTrabajo<Role>(new PrograContext()))
            {
                role = unidad.genericDAL.GetAll();
            }
            return role;
        }

        public bool Remove(Role entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }

        public Role SingleOrDefault(Expression<Func<Role, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
