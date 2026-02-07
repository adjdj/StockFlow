using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class BalanceConfiguration : IEntityTypeConfiguration<Balance> {
    public void Configure(EntityTypeBuilder<Balance> builder) {
        builder.ToTable("Balances");

        builder.HasKey(x => x.Id);


        builder.HasOne(s => s.Resource).WithOne()  // если обратного свойства нет
        .HasForeignKey<Balance>(s => s.ResourceId);  // явно указываем тип сущности

        ///    builder.HasOne(s => s.Resource).WithOne()  // если обратного свойства нет
        ///.HasForeignKey<Balance>(s => s.ResourceId)  // явно указываем тип сущности
        ///.HasColumnName("ResourceId");  // явно указываем имя столбца в БД

        builder.Property(x => x.Quantity)
        .HasPrecision(18, 3)
        .IsRequired();

        builder.Property(x => x.ResourceId)
        .IsRequired();

        //builder.OwnsOne(x => x.Unit, unit => {
        //    unit.Property(u => u.Code)
        //    .HasColumnName("UnitCode")
        //    .HasMaxLength(16)
        //    .IsRequired();
        //    unit.Property(u => u.Ratio)
        //    .HasColumnName("UnitRatio")
        //    .HasPrecision(18, 6)
        //    .IsRequired();
        //});


        builder.HasIndex("ResourceId"/*, "UnitCode"*/)
        .IsUnique();

        //builder.Property<byte[]>("RowVersion")
        //.IsRowVersion();
    }
}