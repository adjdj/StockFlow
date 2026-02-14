/*!
 * @file CreateResourceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

/// <summary>Служба создания ресурса</summary>
public class CreateResourceService {
    private readonly IResourceRepository _repository;

    public CreateResourceService(IResourceRepository repository) {
        _repository = repository;
    }

    public async Task<Result> CreateAsync(string name) {

        var isNameTaken = await _repository.ExistByNameAsync(name);
        if (isNameTaken) {
            return Result.Conflict($"Resource with name '{name}' already exists");
        }

        var resource = new Resource(new Name(name));
        await _repository.AddAsync(resource);
        // !!! add UnitOfWork
        return Result.Success();
    }
}
