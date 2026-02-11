/*!
 * @file CreateClientHandler.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

/// <summary>Служба создания клиента</summary>
public class CreateClientHandler(IClientRepository repository) {
    private readonly IClientRepository _repository = repository;

    public async Task<Result> Handle(CreateClientCommand command) {
        var isNameTaken = await _repository.ExistByNameAsync(command.Name);
        if (isNameTaken) {
            return Result.Conflict($"Unit with name '{command.Name}' already exists");
        }
        var client = new Client(new Name(command.Name), new Address(command.Address));
        await _repository.AddAsync(client);
        return Result.Success();
    }
}
