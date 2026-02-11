/*!
 * @file CreateUnitHandler.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

/// <summary>Служба создания единицы измерения</summary>
public class CreateUnitHandler {
    private readonly IUnitRepository _repository;

    public CreateUnitHandler(IUnitRepository repository) {
        _repository = repository;
    }

    public async Task<Result> Handle(CreateUnitCommand command) {
        var isNameTaken = await _repository.ExistByNameAsync(command.Name);
        if (isNameTaken) {
            return Result.Conflict($"Unit with name '{command.Name}' already exists");
        }
        var unit = new Unit(new Name(command.Name));
        await _repository.AddAsync(unit);
        return Result.Success();
    }
}
