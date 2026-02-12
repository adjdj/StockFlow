/*!
 * @file IReceiptQueryRepository.cs
 * @brief Интерфейс доступа к репозиторию для чтения (CQRS)
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Application.ReadModel;

namespace StockFlow.Application.Repositories;

public interface IReceiptQueryRepository {
    Task<ReceiptDocumentDto?> GetByIdAsync(Guid id);
}