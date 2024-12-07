using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Descriptions).IsRequired().HasMaxLength(255);

        builder.Property(u => u.Quantity).HasColumnType("numeric(15,2)");

        builder.Property(u => u.Price).HasColumnType("numeric(15,2)");

        builder.Property(u => u.Discounts).HasColumnType("numeric(15,2)");

        builder.Property(u => u.TotalAmount).HasColumnType("numeric(15,2)");

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);


        builder.HasOne(u => u.Sale)
                .WithMany(x => x.Products)
                .HasForeignKey(u => u.SaleId)
                .OnDelete(DeleteBehavior.ClientNoAction);

    }
}