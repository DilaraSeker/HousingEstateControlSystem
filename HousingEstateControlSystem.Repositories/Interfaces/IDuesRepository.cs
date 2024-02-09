using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Interfaces
{
    public interface IDuesRepository
    {
        Dues GetDuesById(int duesId);
        List<Dues> GetAllDues();
        Dues AddDues(Dues dues);
        void UpdateDues(Dues dues);
        void DeleteDues(int duesId);
    }
}
