using Microsoft.EntityFrameworkCore;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Condo> Condos { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Bill> Bills { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
