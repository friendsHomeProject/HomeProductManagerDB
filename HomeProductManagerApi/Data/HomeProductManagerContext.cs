using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class HomeProductManagerContext : DbContext
    {
        public HomeProductManagerContext(DbContextOptions<HomeProductManagerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
