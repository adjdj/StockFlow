using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockFlow.Application.Repositories;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=stockflow.db"));

        services.AddScoped<IResourceRepository, ResourceRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IBalanceRepository, BalanceRepository>();
        services.AddScoped<IReceiptDocumentRepository, ReceiptDocumentRepository>();
        //services.AddScoped<IReceiptItemRepository, ReceiptItemRepository>();
        //services.AddScoped<IShipmentDocumentRepository, ShipmentDocumentRepository>();
        return services;
    }
}