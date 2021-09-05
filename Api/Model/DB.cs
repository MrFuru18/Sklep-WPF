using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class DB : IdentityDbContext<User>// DbContext
    {
        public override DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Imager { get; set; }

        public DB(DbContextOptions<DB> opt) : base(opt)
        {
            Database.Migrate();
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //SaveChanges();
        }
        public DB():base() {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(x => x.Id);

            builder.Entity<Address>()
                .HasKey(x => x.id);

            builder.Entity<Order>()
                .HasKey(x => x.id);

            builder.Entity<OrderItem>()
                .HasKey(x => x.id);

            builder.Entity<Product>()
                .HasKey(x => x.id);

            builder.Entity<Image>()
                .HasKey(x => x.id);

            base.OnModelCreating(builder);
        }
    }
}
