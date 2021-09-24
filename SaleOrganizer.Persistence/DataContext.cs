using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence.Configurations;
using System;

namespace SaleOrganizer.Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cloth> Clothes { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new TradeEntityTypeConfiguration().Configure(builder.Entity<Cloth>());
        }
    }
}
