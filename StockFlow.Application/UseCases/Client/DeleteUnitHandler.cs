/*!
 * @file DeleteClientHandler.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;
using StockFlow.Application.Repositories;

namespace StockFlow.Application.UseCases;

/// <summary>Служба удаления</summary>
public class DeleteClientHandler(IClientRepository repository) {
    private readonly IClientRepository _repository = repository;

    // !!! add UnitOfWork->SaveAsync()
    public Task Handle(DeleteClientCommand command) => _repository.DeleteAsync(command.Id);
}
