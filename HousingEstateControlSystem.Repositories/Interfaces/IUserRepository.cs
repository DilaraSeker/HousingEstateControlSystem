using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        User AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        
    }
}
