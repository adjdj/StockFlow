using Microsoft.EntityFrameworkCore;
using StockFlow.Domain;

namespace StockFlow.Infrastructure.Persistence;

public class AppDbContext : DbContext {
    public DbSet<Resource> Resources => Set<Resource>();
    public DbSet<Unit> Units => Set<Unit>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Balance> Balances => Set<Balance>();
    public DbSet<ReceiptDocument> ReceiptDocuments => Set<ReceiptDocument>();
    public DbSet<ShipmentDocument> ShipmentDocuments => Set<ShipmentDocument>();
    public DbSet<ReceiptItem> ReceiptItems { get; set; }
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}