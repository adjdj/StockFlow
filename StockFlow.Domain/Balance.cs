/*!
 * @file Balance.cs
 * @brief Агрегат "Баланс" - на складе есть остаток ресурса в конкретной единице измерения
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

/// <summary>
/// Представляет агрегат "Баланс" в системе.
/// Содержит основные свойства: идентификатор, идентификатор ресурса, идентификатор единицы измерения, количество.
/// </summary>
public class Balance {
    /// <summary>Идентификатор</summary>
    public Guid Id { get; private set; }

    /// <summary>Идентификатор ресурса</summary>
    public Guid ResourceId { get; private set; }

    /// <summary>Идентификатор единицы измерения</summary>
    public Guid UnitId { get; private set; }

    /// <summary>Количество</summary>
    /// <remarks>
    /// Выделить в value-object
    /// </remarks>
    public decimal Quantity { get; private set; }

    /// <summary>Навигация для EF</summary>
    public Resource? Resource { get; set; } = null;

    /// <summary>Навигация для EF</summary>
    public Unit? Unit { get; set; } = null;

    /// <summary>Конструктор для EF</summary>
    private Balance() { }

    /// <summary>Агрегат "Баланс" в системе (конструктор)</summary>
    /// <param name="resourceId">Идентификатор ресурса</param>
    /// <param name="unitId">Идентификатор единицы измерения</param>
    public Balance(Guid resourceId, Guid unitId) {
        Id = Guid.NewGuid();
        ResourceId = resourceId;
        UnitId = unitId;
        Quantity = 0;
    }

    /// <summary>Увеличивает значение баланса</summary>
    /// <param name="amount">Велиина изменения</param>
    public void Increase(decimal amount) {
        Console.WriteLine("!!!!  Balance.Increase(amount = {0})", amount);
        if (amount <= 0)
            throw new DomainException("Неверное количество");
        Quantity += amount;
    }

    /// <summary>Уменьшает значение баланса</summary>
    /// <param name="amount">Велиина изменения</param>
    public void Decrease(decimal amount) {
        if (amount <= 0)
            throw new DomainException("Неверное количество");
        if (Quantity < amount)
            throw new DomainException("Недостаточный баланс");
        Quantity -= amount;
    }
}