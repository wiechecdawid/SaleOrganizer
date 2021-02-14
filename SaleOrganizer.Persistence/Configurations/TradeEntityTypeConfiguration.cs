using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleOrganizer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Persistence.Configurations
{
    public class TradeEntityTypeConfiguration : IEntityTypeConfiguration<Cloth>
    {
        public void Configure(EntityTypeBuilder<Cloth> builder)
        {
            builder
                .HasMany(c => c.Offerings)
                .WithOne(t => t.Cloth)
                .HasForeignKey(t => t.ClothId);
            builder
                .HasMany(c => c.Purchases)
                .WithOne(t => t.Cloth)
                .HasForeignKey(t => t.ClothId);
        }
    }
}
