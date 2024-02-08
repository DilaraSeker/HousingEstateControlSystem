using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Interfaces
{
    public interface ICondoRepository
    {
        Condo GetCondoById(int condoId);
        List<Condo> GetAllCondos();
        void AddCondo(Condo condo);
        void UpdateCondo(Condo condo);
        void DeleteCondo(int condoId);
    }
}
