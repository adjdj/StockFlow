using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class ShipmentDocumentConfiguration : IEntityTypeConfiguration<ShipmentDocument> {
    public void Configure(EntityTypeBuilder<ShipmentDocument> builder) {
        builder.ToTable("ShipmentDocuments");
        builder.HasIndex(x => x.Number).IsUnique();
        //builder.Property<byte[]>("RowVersion").IsRowVersion();
    }
}