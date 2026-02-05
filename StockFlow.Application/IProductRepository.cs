/*!
 * @file IProductRepository.cs
 * @brief Интерфейс доступа к репозиторию
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application;

public interface IProductRepository {
    Task AddAsync(Product product);
    Task<Product?> GetAsync(Guid id);
    Task<IReadOnlyList<Product>> GetAllAsync();
    Task SaveAsync();
}