/*!
 * @file DeleteResourceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Application.Repositories;
namespace StockFlow.Application.UseCases;

/// <summary>Служба удаления ресурса</summary>
public class DeleteResourceService {
    private readonly IResourceRepository _repository;

    public DeleteResourceService(IResourceRepository repository) {
        _repository = repository;
    }

    public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
}