using Microsoft.EntityFrameworkCore;
using StockFlow.Domain.Aggregates;

namespace StockFlow.Infrastructure.Persistence;

public class StockFlowDbContext : DbContext
{
    public DbSet<Resource> Resources => Set<Resource>();

    public StockFlowDbContext(DbContextOptions<StockFlowDbContext> options)
        : base(options)
    {
    }
}