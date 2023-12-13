using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext () { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

         public DbSet<Car> Cars {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasDiscriminator<int>("UserType")
            .HasValue<User>(0)  
            .HasValue<Owner>(1)
            .HasValue<Seller>(2);
                
            base.OnModelCreating(modelBuilder);

        }
    }
}
