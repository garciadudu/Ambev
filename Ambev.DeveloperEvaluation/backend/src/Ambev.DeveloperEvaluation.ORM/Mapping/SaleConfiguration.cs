using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Number)
               .HasColumnType("bigint");

        builder.Property(u => u.Date).HasColumnType("timestamp with time zone");
        builder.Property(u => u.TotalSalesAmount).HasColumnType("numeric(15,2)");
        builder.Property(u => u.Branch);


        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);


        builder.HasOne(u => u.Customer)
            .WithMany(x => x.Sales)
            .HasForeignKey(u => u.CustomerId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasOne(u => u.Filiation)
            .WithMany(x => x.Sales)
            .HasForeignKey(u => u.FiliationId)
            .OnDelete(DeleteBehavior.ClientNoAction);

    }
}
