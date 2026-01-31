/*!
 * @file Entity.cs
 * @brief Общий базовый класс для агрегатов
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain.Common;

/// <summary>
/// Базовая сущность с идентификатором
/// </summary>
public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}