using Microsoft.EntityFrameworkCore;
using Suppliers.Infrastructure.Models;

namespace Suppliers.Infrastructure.Context
{
    public class SupplierContext : DbContext
    {

        public SupplierContext(DbContextOptions<SupplierContext> options) : base(options)
        {
        }
        
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<HighRisk> HighRisks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=SPIGISAURIO\\MSSQLSERVER01;Database=suppliers;Encrypt=false;Integrated Security=SSPI;persist security info=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings and relationships here if needed
            // For example:
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);
            modelBuilder.Entity<Supplier>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Supplier>().Property(s => s.LegalName).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.TradeName).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.TaxId).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.PhoneNumber).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.Email).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.Website).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.Address).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.Country).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.AnnualRevenue).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.LastEdited).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.HighRisks).IsRequired();
        }
    }
}