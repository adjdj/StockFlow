/*!
 * @file IClientRepository.cs
 * @brief Интерфейс доступа к репозиторию
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application.Repositories;

public interface IClientRepository {
    Task AddAsync(Client unit);
    Task DeleteAsync(Guid id);
    Task<IReadOnlyList<Client>> GetAllAsync();

    Task SaveAsync();

    Task<Client?> GetByIdAsync(Guid id);
    Task<bool> ExistByNameAsync(string name);
    Task<bool> ExistByNameExceptAsync(string name, Guid exceptId);
}