using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApiContext : DbContext
    {
        public ApiContext() : base("name=HomeProductManagerEntities")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
