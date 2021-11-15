using Microsoft.EntityFrameworkCore;
using MVVM_Shop.SqlTables;

namespace MVVM_Shop
{
    public class SqlDb : DbContext
    {
        public SqlDb(DbContextOptions<SqlDb> options)
            : base(options)
        {
        }

        public DbSet<Suplier> Supliers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suplier>().ToTable("Supliers");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategories");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
