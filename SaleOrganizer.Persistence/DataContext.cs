using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Domain;
using System;

namespace SaleOrganizer.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        DbSet<Cloth> Clothes { get; set; }
    }
}
