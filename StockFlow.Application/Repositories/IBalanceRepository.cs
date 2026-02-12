/*!
 * @file IBalanceRepository.cs
 * @brief Интерфейс доступа к репозиторию
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application.Repositories;

public interface IBalanceRepository {
    Task<Balance?> GetAsync(Guid resourceId, Guid unitId);
    Task AddAsync(Balance balance);
    Task SaveAsync();
    Task<IReadOnlyList<Balance>> GetAllAsync();
}