using Microsoft.EntityFrameworkCore;
using HousingEstateControlSystem.Repositories.Models;

namespace HousingEstateControlSystem.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Condo> Condos { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Bill> Bills { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User tablosu için anahtar tanımlaması
            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            // Condo tablosu için anahtar tanımlaması
            modelBuilder.Entity<Condo>().HasKey(c => c.CondoId);

            // Payment tablosu için anahtar tanımlaması
            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);

            // Dues tablosu için anahtar tanımlaması
            modelBuilder.Entity<Dues>().HasKey(d => d.DuesId);

            // Bill tablosu için anahtar tanımlaması
            modelBuilder.Entity<Bill>().HasKey(b => b.BillId);

            // User ve Condo arasındaki ilişkiyi tanımlama
            modelBuilder.Entity<User>()
                .HasOne(u => u.Condo)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CondoId)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili Condo silindiğinde User'ları da sil

            // Payment ve User arasındaki ilişkiyi tanımlama
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili User silindiğinde Payment'lar da sil

            // Dues ve Condo arasındaki ilişkiyi tanımlama
            modelBuilder.Entity<Dues>()
                .HasOne(d => d.Condo)
                .WithMany(c => c.Dues)
                .HasForeignKey(d => d.CondoId)
                .OnDelete(DeleteBehavior.Cascade); // İlişkili Condo silindiğinde Dues'ları da sil

            // Bill ve Condo arasındaki ilişkiyi tanımlama
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
