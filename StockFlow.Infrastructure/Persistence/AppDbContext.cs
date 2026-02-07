using Microsoft.EntityFrameworkCore;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class AppDbContext : DbContext {
    public DbSet<Resource> Resources => Set<Resource>();

    public DbSet<Balance> Balances => Set<Balance>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {
    }

    /// <summary>
    /// Переопределяемый метод для конфигурации модели EF Core.
    /// Позволяет:
    /// - задать имена таблиц и колонок;
    /// - настроить связи между сущностями (один‑ко‑многим, многие‑ко‑многим);
    /// - определить индексы и ограничения;
    /// - переопределить соглашения EF Core по умолчанию.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Мост между вашими настройками и внутренними механизмами фреймворка
        base.OnModelCreating(modelBuilder);

        // Явно указываем первичный ключ для таблиц
        //modelBuilder.Entity<Product>().HasKey(p => p.Id);
        //modelBuilder.Entity<StockItem>().HasKey(s => s.ProductId);

        /// <summary>
        /// Настраивает отношение один‑к‑одному между StockItem и Product:
        /// - HasOne(s => s.Product): у StockItem есть одно связанное Product.
        /// - WithOne(): у Product может быть не более одного StockItem (без навигационного свойства).
        /// - HasForeignKey: внешний ключ ProductId расположен в сущности StockItem.
        /// </summary>
        // Связь 1 к 1 (товар-остаток)
        //modelBuilder.Entity<StockItem>().HasOne(s => s.Product).WithOne().HasForeignKey<StockItem>(s => s.ProductId);


        modelBuilder.Entity<Resource>().HasKey(p => p.Id);
        modelBuilder.Entity<Resource>().Property(u => u.Name).HasConversion(name => name.Value, value => new Name(value)).HasMaxLength(255); // в БД (string) // из БД

        //modelBuilder.Entity<Balance>().HasKey(x => x.Id);
        //modelBuilder.Entity<Balance>().Property(x => x.Quantity).HasPrecision(18, 3).IsRequired();
        //modelBuilder.Entity<Balance>().Property(x => x.ResourceId).IsRequired();


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}