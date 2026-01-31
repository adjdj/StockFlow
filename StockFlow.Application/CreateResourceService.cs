using StockFlow.Domain.Aggregates;

namespace StockFlow.Application.Resources;

public class CreateResourceService
{
    private readonly IResourceRepository _repository;

    public CreateResourceService(IResourceRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResourceDto> CreateAsync(string name, CancellationToken ct)
    {
        var resource = new Resource(name);

        await _repository.AddAsync(resource, ct);

        return new ResourceDto(resource.Id, resource.Name);
    }
}
