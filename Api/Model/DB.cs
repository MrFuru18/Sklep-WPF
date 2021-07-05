using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class DB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }


        public DB(DbContextOptions<DB> opt) : base(opt)
        {
            Database.EnsureCreated();
        }
        public DB():base() {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(x => x.id);

            builder.Entity<Address>()
                .HasKey(x => x.id);

            builder.Entity<Order>()
                .HasKey(x => x.id);

            builder.Entity<OrderItem>()
                .HasKey(x => x.id);

            builder.Entity<Product>()
                .HasKey(x => x.id);

            base.OnModelCreating(builder);
        }
    }
}
