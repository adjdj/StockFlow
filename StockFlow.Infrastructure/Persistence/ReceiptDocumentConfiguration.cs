using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class ReceiptDocumentConfiguration : IEntityTypeConfiguration<ReceiptDocument> {
    public void Configure(EntityTypeBuilder<ReceiptDocument> builder) {
        builder.ToTable("ReceiptDocuments");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Number).IsRequired();
        builder.HasMany(d => d.Items)
               .WithOne(i => i.ReceiptDocument)
               .HasForeignKey(i => i.ReceiptDocumentId)
               .OnDelete(DeleteBehavior.Cascade);
        //builder.Property<byte[]>("RowVersion").IsRowVersion();
    }
}