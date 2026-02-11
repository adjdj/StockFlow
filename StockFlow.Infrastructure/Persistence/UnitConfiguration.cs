using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class UnitConfiguration : IEntityTypeConfiguration<Unit> {
    public void Configure(EntityTypeBuilder<Unit> builder) {
        builder.ToTable("Units");
        builder.HasKey(p => p.Id);
        builder.Property(u => u.Name).HasConversion(name => name.Value, value => new Name(value)).HasMaxLength(255); // в БД (string) // из БД
        //builder.Property<byte[]>("RowVersion").IsRowVersion();
    }
}