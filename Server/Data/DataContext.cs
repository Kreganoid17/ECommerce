using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {



        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> cart { get; set; }

        public DbSet<Order> orders { get; set; }


    }
}
