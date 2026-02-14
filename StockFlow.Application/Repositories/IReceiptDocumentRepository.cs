/*!
 * @file IReceiptRepository.cs
 * @brief Интерфейс доступа к репозиторию
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain;

namespace StockFlow.Application.Repositories;

public interface IReceiptDocumentRepository {
    Task<bool> ExistsByNumberAsync(string number);
    Task AddAsync(ReceiptDocument document);
}