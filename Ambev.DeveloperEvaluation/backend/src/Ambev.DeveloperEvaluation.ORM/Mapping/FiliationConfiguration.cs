using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class FiliationConfiguration : IEntityTypeConfiguration<Filiation>
{
    public void Configure(EntityTypeBuilder<Filiation> builder)
    {
        builder.ToTable("Filiations");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Codigo).HasMaxLength(15);

        builder.Property(u => u.Nome).HasMaxLength(100);
    }
}
