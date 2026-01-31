using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Resources;
using StockFlow.Domain.Aggregates;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure.Resources;

public class ResourceRepository : IResourceRepository
{
    private readonly StockFlowDbContext _db;

    public ResourceRepository(StockFlowDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Resource resource, CancellationToken ct)
    {
        _db.Resources.Add(resource);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct)
    {
        var resource = await _db.Resources.FirstOrDefaultAsync(r => r.Id == id, ct);

        if (resource is null)
            return;

        _db.Resources.Remove(resource);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Resource>> GetAllAsync(CancellationToken ct)
    {
        return await _db.Resources
            .AsNoTracking()
            .ToListAsync(ct);
    }
}