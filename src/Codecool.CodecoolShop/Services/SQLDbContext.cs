using Codecool.CodecoolShop.Services.Tables;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Services
{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options)
            : base(options)
        {
        }

       public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
