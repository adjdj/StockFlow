namespace StockFlow.Application.Resources;

public class GetResourcesService
{
    private readonly IResourceRepository _repository;

    public GetResourcesService(IResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ResourceDto>> GetAllAsync(CancellationToken ct)
    {
        var resources = await _repository.GetAllAsync(ct);

        return resources
            .Select(r => new ResourceDto(r.Id, r.Name))
            .ToList();
    }
}