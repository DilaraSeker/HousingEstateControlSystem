using HousingEstateControlSystem.Repositories.Interfaces;
using HousingEstateControlSystem.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HousingEstateControlSystem.Repositories.Implementations
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DatabaseContext _context;

        public UserRoleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole); // Kullanıcı rolünü ekliyoruz
            _context.SaveChanges(); // Değişiklikleri kaydediyoruz
        }

        public void RemoveUserRole(string userId, string roleId)
        {
            var userRoleToRemove = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRoleToRemove != null)
            {
                _context.UserRoles.Remove(userRoleToRemove);
                _context.SaveChanges();
            }
        }

        public List<string> GetUserRoles(string userId)
        {
            var roleIds = _context.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId).ToList();
            return roleIds;
        }
    }
}
