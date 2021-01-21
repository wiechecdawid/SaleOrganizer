using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleOrganizer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Persistence.Configurations
{
    public class TradeEntityTypeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder
                .HasOne(t => t.Cloth)
                .WithMany(c => c.Trades)
                .HasForeignKey(t => t.ClothId);
        }
    }
}
