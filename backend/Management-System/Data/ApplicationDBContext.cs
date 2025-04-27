using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Management_System.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<Product>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Category>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<CartItem>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
        }
    }
}