using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class ClientConfiguration : IEntityTypeConfiguration<Client> {
    public void Configure(EntityTypeBuilder<Client> builder) {
        builder.ToTable("Clients");
        builder.HasKey(p => p.Id);
        builder.Property(u => u.Name).HasConversion(name => name.Value, value => new Name(value)).HasMaxLength(255); // в БД (string) // из БД
        builder.Property(u => u.Address).HasConversion(name => name.Value, value => new Address(value)).HasMaxLength(500); // в БД (string) // из БД
        //builder.Property<byte[]>("RowVersion").IsRowVersion();
    }
}