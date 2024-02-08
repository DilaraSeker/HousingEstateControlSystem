using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Implementations
{
    public class CondoRepository : ICondoRepository
    {
        private readonly DatabaseContext _context;

        public CondoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Condo GetCondoById(int condoId)
        {
            return _context.Condos.FirstOrDefault(c => c.CondoId == condoId);
        }

        public List<Condo> GetAllCondos()
        {
            return _context.Condos.ToList();
        }

        public void AddCondo(Condo condo)
        {
            _context.Condos.Add(condo);
            _context.SaveChanges();
        }

        public void UpdateCondo(Condo condo)
        {
            _context.Condos.Update(condo);
            _context.SaveChanges();
        }

        public void DeleteCondo(int condoId)
        {
            var condo = _context.Condos.FirstOrDefault(c => c.CondoId == condoId);
            if (condo != null)
            {
                _context.Condos.Remove(condo);
                _context.SaveChanges();
            }
        }
    }
}
