/*!
 * @file UpdateResourceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application;

/// <summary>Служба создания ресурса</summary>
public class UpdateResourceService {
    private readonly IResourceRepository _repository;

    public UpdateResourceService(IResourceRepository repository) {
        _repository = repository;
    }

    public async Task<Result> UpdateAsync(Guid id, string newName) {
        var resource = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Resource not found");

        // Уникальность
        // Глобальный инвариант
        if (await _repository.ExistByNameExceptAsync(newName, id))
            throw new InvalidOperationException($"Resource with name '{newName}' already exists");

        resource.Rename(new Name(newName));
        await _repository.SaveAsync();

        return Result.Success();
        //var resource = new Resource(new Name(name));
        //await _repository.AddAsync(resource);
        //return Result.Success();
    }
}
