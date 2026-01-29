// Application **не знает**, как хранятся данные
// - только контракт


using StockFlow.Domain.Aggregates;

namespace StockFlow.Application.Resources;

public interface IResourceRepository
{
    Task AddAsync(Resource resource, CancellationToken ct);
    Task DeleteAsync(Guid id, CancellationToken ct);
    Task<IReadOnlyList<Resource>> GetAllAsync(CancellationToken ct);
}