using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class ReceiptItemConfiguration : IEntityTypeConfiguration<ReceiptItem> {
    public void Configure(EntityTypeBuilder<ReceiptItem> builder) {
        builder.ToTable("ReceiptItems");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Quantity).IsRequired();
        //builder.Property<byte[]>("RowVersion").IsRowVersion();
    }
}