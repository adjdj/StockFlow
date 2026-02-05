using Microsoft.EntityFrameworkCore;
using StockFlow.Application;
using StockFlow.Domain;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class InventoryBalanceRepository : IBalanceRepository {
    private readonly AppDbContext _db;


    public InventoryBalanceRepository(AppDbContext db) {
        _db = db;
    }


    public async Task<Balance?> GetAsync(Guid resourceId/*,UnitOfMeasure unit*/) {
        return await _db.Balances.FirstOrDefaultAsync(x => x.ResourceId == resourceId /*&& x.Unit.Code == unit.Code*/);
    }


    public async Task AddAsync(Balance balance) {
        await _db.Balances.AddAsync(balance);
    }


    public async Task SaveAsync() {
        await _db.SaveChangesAsync();
    }
}