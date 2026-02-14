using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource> {
    public void Configure(EntityTypeBuilder<Resource> builder) {
        builder.ToTable("Resources");

        // Явно указываем первичный ключ для таблиц
        /// <summary>
        /// Настраивает отношение один‑к‑одному между StockItem и Product:
        /// - HasOne(s => s.Product): у StockItem есть одно связанное Product.
        /// - WithOne(): у Product может быть не более одного StockItem (без навигационного свойства).
        /// - HasForeignKey: внешний ключ ProductId расположен в сущности StockItem.
        /// </summary>
        builder.HasKey(p => p.Id);
        builder.Property(u => u.Name).HasConversion(name => name.Value, value => new Name(value)).HasMaxLength(255); // в БД (string) // из БД
        //builder.Property<byte[]>("RowVersion").IsRowVersion();
    }
}