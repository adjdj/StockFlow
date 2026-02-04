/*!
 * @file IResourceRepository.cs
 * @brief Интерфейс доступа к репозиторию
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application;

public interface IResourceRepository {
    Task AddAsync(Resource resource);
    Task DeleteAsync(Guid id);
    Task<IReadOnlyList<Resource>> GetAllAsync();
}