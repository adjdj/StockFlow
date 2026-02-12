/*!
 * @file IUnitOfWork.cs
 * @brief Интерфейс для организации атомарного доступа
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Application.Repositories;

public interface IUnitOfWork {
    Task BeginTransactionAsync();
    Task CommitAsync();
}