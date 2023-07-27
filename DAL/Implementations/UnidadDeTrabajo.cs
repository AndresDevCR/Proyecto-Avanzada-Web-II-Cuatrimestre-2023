using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo<TEntity> : IDisposable where TEntity : class
    {
        private readonly PrograContext _prograContext;
        public IDALGenerico<TEntity> genericDAL;

        public UnidadDeTrabajo(PrograContext _context)
        {
            _prograContext = _context;
            genericDAL = new DALGenericoImpl<TEntity>(_prograContext);
        }

        public bool Complete()
        {
            try
            {
                _prograContext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                string msj = ex.Message;
                return false;

            }
        }
        public void Dispose()
        {
            _prograContext.Dispose();
        }

    }
}
