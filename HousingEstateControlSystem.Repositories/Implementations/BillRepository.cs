using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Implementations
{
    public class BillRepository : IBillRepository
    {
        private readonly DatabaseContext _context;

        public BillRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Bill GetBillById(int billId)
        {
            return _context.Bills.FirstOrDefault(b => b.BillId == billId);
        }

        public List<Bill> GetAllBills()
        {
            return _context.Bills.ToList();
        }

        public Bill AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return bill;
        }

        public void UpdateBill(Bill bill)
        {
            _context.Bills.Update(bill);
            _context.SaveChanges();
        }

        public void DeleteBill(int billId)
        {
            var bill = _context.Bills.FirstOrDefault(b => b.BillId == billId);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                _context.SaveChanges();
            }
        }
    }
}
