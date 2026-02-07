using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockFlow.Application;
using StockFlow.Infrastructure.Persistence;
using StockFlow.Infrastructure;

namespace StockFlow.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration) {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=stockflow.db"));


        services.AddScoped<IBalanceRepository, BalanceRepository>();


        return services;
    }
}