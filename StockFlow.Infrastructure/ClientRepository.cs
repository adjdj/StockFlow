using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Repositories;
using StockFlow.Domain;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class ClientRepository(AppDbContext db) : IClientRepository {
    private readonly AppDbContext _db = db;

    public async Task AddAsync(Client client) {
        _db.Clients.Add(client);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id) {
        var client = await _db.Clients.FirstOrDefaultAsync(r => r.Id == id);
        if (client is null)
            return;
        _db.Clients.Remove(client);
        await _db.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Client>> GetAllAsync() {
        return await _db.Clients.AsNoTracking().ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(Guid id) {
        return await _db.Clients.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task SaveAsync() {
        await _db.SaveChangesAsync();
    }

    public async Task<bool> ExistByNameAsync(string name) {
        return await _db.Clients.AnyAsync(r => r.Name == new Name(name));
    }
    public async Task<bool> ExistByNameExceptAsync(string name, Guid exceptId) {
        return await _db.Clients.AnyAsync(r => r.Name == new Name(name) && r.Id != exceptId);
    }
}