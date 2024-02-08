using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
