/*!
 * @file IUnitRepository.cs
 * @brief Интерфейс доступа к репозиторию
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application.Repositories;

public interface IUnitRepository {
    Task AddAsync(Unit unit);
    Task DeleteAsync(Guid id);
    Task<IReadOnlyList<Unit>> GetAllAsync();

    Task SaveAsync();

    Task<Unit?> GetByIdAsync(Guid id);
    Task<bool> ExistByNameAsync(string name);
    Task<bool> ExistByNameExceptAsync(string name, Guid exceptId);
}