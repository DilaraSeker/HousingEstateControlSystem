using HousingEstateControlSystem.Repositories.Models;
using System.Collections.Generic;

namespace HousingEstateControlSystem.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        void AddUserRole(UserRole userRole);
        void RemoveUserRole(string userId, string roleId);
        List<string> GetUserRoles(string userId);
    }
}
