using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class BalanceConfiguration : IEntityTypeConfiguration<Balance> {
    public void Configure(EntityTypeBuilder<Balance> builder) {
        //builder.ToTable("Balances");
        //
        //builder.HasKey(x => x.Id);
        //
        //builder.HasOne(s => s.Resource).WithOne()  // если обратного свойства нет
        //.HasForeignKey<Balance>(s => s.ResourceId);  // явно указываем тип сущности
        //
        //builder.Property(x => x.ResourceId)
        //.IsRequired();
        //
        //builder.HasOne(s => s.Unit).WithOne()  // если обратного свойства нет
        //.HasForeignKey<Balance>(s => s.UnitId);  // явно указываем тип сущности
        //
        //builder.Property(x => x.UnitId)
        //.IsRequired();
        //
        //builder.Property(x => x.Quantity)
        //.HasPrecision(18, 3)
        //.IsRequired();
        //
        //builder.HasIndex("ResourceId", "UnitId")
        //.IsUnique();
        //
        ////builder.Property<byte[]>("RowVersion")
        ////.IsRowVersion();

        /// Переписал
        builder.ToTable("Balances");

        builder.HasKey(x => x.Id);

        // Связь: один Resource → много Balances
        builder.HasOne(b => b.Resource)
            .WithMany()
            .HasForeignKey(b => b.ResourceId)
            .OnDelete(DeleteBehavior.Restrict);  // явное поведение

        builder.Property(b => b.ResourceId)
            .IsRequired();

        // Связь: один Unit → много Balances
        builder.HasOne(b => b.Unit)
            .WithMany()
            .HasForeignKey(b => b.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(b => b.UnitId)
            .IsRequired();

        builder.Property(b => b.Quantity)
            .HasPrecision(18, 3)
            .IsRequired();

        // Уникальный индекс только если требуется по логике
        builder.HasIndex(b => new { b.ResourceId, b.UnitId })
            .IsUnique();  // убрать, если не нужно

        //builder.Property<byte[]>("RowVersion").IsRowVersion();
    }
}