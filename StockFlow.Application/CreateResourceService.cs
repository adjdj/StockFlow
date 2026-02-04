/*!
 * @file CreateResourceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application;

/// <summary>Служба создания ресурса</summary>
public class CreateResourceService {
    private readonly IResourceRepository _repository;

    public CreateResourceService(IResourceRepository repository) {
        _repository = repository;
    }

    public async Task<Result> CreateAsync(string name) {
        var resource = new Resource(new Name(name));
        await _repository.AddAsync(resource);
        return Result.Success();
    }
}
