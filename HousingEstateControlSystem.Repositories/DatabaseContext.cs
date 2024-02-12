using Microsoft.EntityFrameworkCore;
using HousingEstateControlSystem.Repositories.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HousingEstateControlSystem.Repositories
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Condo> Condos { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Bill> Bills { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User ve UserRole arasındaki ilişki
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            // Change UserRole table name
            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            // Condo, Payment, Dues ve Bill tabloları için key
            modelBuilder.Entity<Condo>().HasKey(c => c.CondoId);
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<Dues>().HasKey(d => d.DuesId);
            modelBuilder.Entity<Bill>().HasKey(b => b.BillId);

            // User ve Condo arasındaki ilişki
            modelBuilder.Entity<User>()
                .HasOne(u => u.Condo)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CondoId)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili Condo silindiğinde User'ları da sil

            // Payment ve User arasındaki ilişki
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili User silindiğinde Payment'lar da sil

            // Dues ve Condo arasındaki ilişki
            modelBuilder.Entity<Dues>()
                .HasOne(d => d.Condo)
                .WithMany(c => c.Dues)
                .HasForeignKey(d => d.CondoId)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili Condo silindiğinde Dues'ları da sil

            // Bill ve Condo arasındaki ilişki
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Condo)
                .WithMany(c => c.Bills)
                .HasForeignKey(b => b.CondoId)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili Condo silindiğinde Bill'leri de sil

            // Amount özelliklerinin SQL sunucu sütun türlerini belirtme
            modelBuilder.Entity<Bill>()
                .Property(b => b.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Dues>()
                .Property(d => d.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

        }
    }
}