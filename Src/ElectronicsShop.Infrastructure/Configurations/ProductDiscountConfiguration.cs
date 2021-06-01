using ElectronicsShop.Domain.Common.Enums;
using ElectronicsShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ElectronicsShop.Infrastructure.Configurations
{
    public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.Property(e => e.Type)
                .HasConversion(v => v.ToString(), v => (DiscountType)Enum.Parse(typeof(DiscountType), v))
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
