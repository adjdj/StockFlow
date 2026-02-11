using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Repositories;
using StockFlow.Domain;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class UnitRepository(AppDbContext db) : IUnitRepository {
    private readonly AppDbContext _db = db;

    public async Task AddAsync(Unit unit) {
        _db.Units.Add(unit);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id) {
        var unit = await _db.Units.FirstOrDefaultAsync(r => r.Id == id);
        if (unit is null)
            return;
        _db.Units.Remove(unit);
        await _db.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Unit>> GetAllAsync() {
        return await _db.Units.AsNoTracking().ToListAsync();
    }

    public async Task<Unit?> GetByIdAsync(Guid id) {
        return await _db.Units.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task SaveAsync() {
        await _db.SaveChangesAsync();
    }

    public async Task<bool> ExistByNameAsync(string name) {
        return await _db.Units.AnyAsync(r => r.Name == new Name(name));
    }
    public async Task<bool> ExistByNameExceptAsync(string name, Guid exceptId) {
        return await _db.Units.AnyAsync(r => r.Name == new Name(name) && r.Id != exceptId);
    }
}