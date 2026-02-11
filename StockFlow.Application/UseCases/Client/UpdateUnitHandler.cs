/*!
 * @file UpdateClientHandler.cs
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
public class UpdateClientHandler(IClientRepository repository) {
    private readonly IClientRepository _repository = repository;
    public async Task<Result> Handle(UpdateClientCommand command) {
        var client = await _repository.GetByIdAsync(command.Id) ?? throw new KeyNotFoundException("Resource not found");
        var isNameTaken = await _repository.ExistByNameExceptAsync(command.Name, command.Id);
        if (isNameTaken) {
            return Result.Conflict($"Client with name '{command.Name}' already exists");
        }
        client.Rename(new Name(command.Name));
        client.ReplaceAddress(new Address(command.Address));
        await _repository.SaveAsync();
        return Result.Success();
    }
}
