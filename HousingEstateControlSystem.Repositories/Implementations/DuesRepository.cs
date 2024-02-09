using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Implementations
{
    public class DuesRepository : IDuesRepository
    {
        private readonly DatabaseContext _context;

        public DuesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Dues GetDuesById(int duesId)
        {
            return _context.Dues.FirstOrDefault(d => d.DuesId == duesId);
        }

        public List<Dues> GetAllDues()
        {
            return _context.Dues.ToList();
        }

        public Dues AddDues(Dues dues)
        {
            _context.Dues.Add(dues);
            _context.SaveChanges();
            return dues;
        }

        public void UpdateDues(Dues dues)
        {
            _context.Dues.Update(dues);
            _context.SaveChanges();
        }

        public void DeleteDues(int duesId)
        {
            var dues = _context.Dues.FirstOrDefault(d => d.DuesId == duesId);
            if (dues != null)
            {
                _context.Dues.Remove(dues);
                _context.SaveChanges();
            }
        }
    }
}
