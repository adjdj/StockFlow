/*!
 * @file IBalanceRepository.cs
 * @brief Интерфейс доступа к репозиторию
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application;

public interface IBalanceRepository {
    Task<Balance?> GetAsync(Guid resourceId/*, UnitOfMeasure unit*/);
    Task AddAsync(Balance balance);
    Task SaveAsync();
    Task<IReadOnlyList<Balance>> GetAllAsync();
}