using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DatabaseContext _context;

        public PaymentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public IEnumerable<Payment> GetPaymentsByUserId(int userId)
        {
            return _context.Payments.Where(p => p.UserId == userId).ToList();
        }

        public IEnumerable<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Payments.Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate).ToList();
        }

        public IEnumerable<Payment> GetPaymentsByType(PaymentType paymentType)
        {
            return _context.Payments.Where(p => p.PaymentType == paymentType).ToList();
        }

        public decimal GetTotalAmountPaidByUser(int userId)
        {
            return _context.Payments.Where(p => p.UserId == userId).Sum(p => p.Amount);
        }
    }
}
