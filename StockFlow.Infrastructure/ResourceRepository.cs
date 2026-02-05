using Microsoft.EntityFrameworkCore;
using StockFlow.Application;
using StockFlow.Domain;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class ResourceRepository : IResourceRepository {
    private readonly AppDbContext _db;

    public ResourceRepository(AppDbContext db) {
        _db = db;
    }

    public async Task AddAsync(Resource resource) {
        _db.Resources.Add(resource);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id) {
        var resource = await _db.Resources.FirstOrDefaultAsync(r => r.Id == id);

        if (resource is null)
            return;

        _db.Resources.Remove(resource);
        await _db.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Resource>> GetAllAsync() {
        return await _db.Resources.AsNoTracking().ToListAsync();
    }

    //
    public async Task<Resource?> GetByIdAsync(Guid id) {
        return await _db.Resources.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task SaveAsync() {
        await _db.SaveChangesAsync();
    }

    //
    public async Task<bool> ExistByNameAsync(string name) {
        //return await _db.Resources.AnyAsync(r => r.Name.Value == name);
        return await _db.Resources.AnyAsync(r => r.Name == new Name(name));
    }
    public async Task<bool> ExistByNameExceptAsync(string name, Guid exceptId) {
        //return await _db.Resources.AnyAsync(r => r.Name.Value == name && r.Id != exceptId);
        return await _db.Resources.AnyAsync(r => r.Name == new Name(name) && r.Id != exceptId);
    }
}