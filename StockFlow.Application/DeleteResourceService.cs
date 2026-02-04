/*!
 * @file CreateResourceService.cs
 * @brief -
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Application;

/// <summary>Служба удаления ресурса</summary>
public class DeleteResourceService {
    private readonly IResourceRepository _repository;

    public DeleteResourceService(IResourceRepository repository) {
        _repository = repository;
    }

    public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
}