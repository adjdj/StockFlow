/*!
 * @file Entity.cs
 * @brief Общий базовый класс для сущностей
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Базовая сущность с идентификатором
/// </summary>
public abstract class BaseEntity {
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public bool IsArchived { get; set; } = false;
}