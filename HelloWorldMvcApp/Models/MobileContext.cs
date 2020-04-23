using Microsoft.EntityFrameworkCore;

namespace MobileStore.Models
{
    public interface IDbContext
    {
        DbSet<Phone> Phones { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }

    public class MobileContext : DbContext, IDbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}