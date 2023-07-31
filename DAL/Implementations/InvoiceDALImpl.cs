using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class InvoiceDalImpl : IInvoiceDAL
    {
        private readonly IGenericDal<Invoice> _invoiceRepository;

        public InvoiceDalImpl(PrograContext dbContext)
        {
            _invoiceRepository = new GenericRepository<Invoice>(dbContext);
        }

        public async Task Add(Invoice entity)
        {
            await _invoiceRepository.Add(entity);
        }

        public async Task Delete(Invoice entity)
        {
            await _invoiceRepository.Delete(entity);
        }

        public async Task<IEnumerable<Invoice>> Find(Expression<Func<Invoice, bool>> predicate)
        {
            return await _invoiceRepository.Find(predicate);
        }

        public async Task<IEnumerable<Invoice>> GetAll()
        {
            return await _invoiceRepository.GetAll();
        }

        public async Task<Invoice> GetById(int id)
        {
            return await _invoiceRepository.GetById(id);
        }

        public async Task Update(Invoice entity)
        {
            await _invoiceRepository.Update(entity);
        }
    }
}
