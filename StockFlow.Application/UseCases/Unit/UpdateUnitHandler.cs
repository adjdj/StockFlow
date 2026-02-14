/*!
 * @file UpdateUnitHandler.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

/// <summary>Служба обновления единицы измерения</summary>
public class UpdateUnitHandler(IUnitRepository repository) {
    private readonly IUnitRepository _repository = repository;
    public async Task<Result> Handle(UpdateUnitCommand command) {
        var resource = await _repository.GetByIdAsync(command.Id) ?? throw new KeyNotFoundException("Resource not found");
        var isNameTaken = await _repository.ExistByNameExceptAsync(command.Name, command.Id);
        if (isNameTaken) {
            return Result.Conflict($"Resource with name '{command.Name}' already exists");
        }
        resource.Rename(new Name(command.Name));
        // !!! перейти UnitOfWork->SaveAsync();
        await _repository.SaveAsync();
        return Result.Success();
    }
}
