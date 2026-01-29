namespace StockFlow.Application.Resources;

public class DeleteResourceService
{
    private readonly IResourceRepository _repository;

    public DeleteResourceService(IResourceRepository repository)
    {
        _repository = repository;
    }

    public Task DeleteAsync(Guid id, CancellationToken ct)
        => _repository.DeleteAsync(id, ct);
}