/*!
 * @file DeleteUnitHandler.cs
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
public class DeleteUnitHandler(IUnitRepository repository) {
    private readonly IUnitRepository _repository = repository;

    // !!! add UnitOfWork
    public Task Handle(DeleteUnitCommand command) => _repository.DeleteAsync(command.Id);
}
