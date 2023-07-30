using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class PaymentDalImpl : IPaymentDAL
    {
        private readonly IGenericDal<Payment> _paymentRepository;

        public PaymentDalImpl(PrograContext dbContext)
        {
            _paymentRepository = new GenericRepository<Payment>(dbContext);
        }

        public async Task Add(Payment entity)
        {
            await _paymentRepository.Add(entity);
        }

        public async Task Delete(Payment entity)
        {
            await _paymentRepository.Delete(entity);
        }

        public async Task<IEnumerable<Payment>> Find(Expression<Func<Payment, bool>> predicate)
        {
            return await _paymentRepository.Find(predicate);
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _paymentRepository.GetAll();
        }

        public async Task<Payment> GetById(int id)
        {
            return await _paymentRepository.GetById(id);
        }

        public async Task Update(Payment entity)
        {
            await _paymentRepository.Update(entity);
        }
    }
}
