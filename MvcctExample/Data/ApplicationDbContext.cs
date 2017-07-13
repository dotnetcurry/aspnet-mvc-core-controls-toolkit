using Microsoft.EntityFrameworkCore;
using MvcctExample.Models;
namespace MvcctExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Supplier>()
                .HasMany(m => m.Products)
                .WithOne(m => m.Supplier)
                .HasForeignKey(m => m.SupplierId);

            builder.Entity<Supplier>()
                .HasIndex(m => m.CompanyName);
            builder.Entity<Food>()
                .HasIndex(m => m.ProductName);
            builder.Entity<Food>()
                .HasIndex(m => m.UnitPrice);
            builder.Entity<Food>()
                .HasIndex(m => m.IsDiscontinued);
        }
    }
}
