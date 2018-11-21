using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HomeProductManagerContext : DbContext
    {
        public HomeProductManagerContext(DbContextOptions<HomeProductManagerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PeriodType> PeriodTypes { get; set; }

        public DbSet<UnitType> UnitTypes { get; set; }

    }
}
