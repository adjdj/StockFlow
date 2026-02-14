/*!
 * @file BaseEntity.cs
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
    /// <summary>Идентификатор</summary>
    public Guid Id { get; protected set; } = Guid.NewGuid();

    /// <summary>Состояние: в архиве</summary>
    public bool IsArchived { get; protected set; } = false;
}