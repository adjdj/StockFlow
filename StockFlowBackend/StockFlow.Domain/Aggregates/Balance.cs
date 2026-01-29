/*!
 * @file Balance.cs
 * @brief Агрегат баланс в системе
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Domain.Common;

namespace StockFlow.Domain.Aggregates;

public class Balance : Entity
{
    public Guid ResourceId { get; private set; }
    public decimal Quantity { get; private set; }

    private Balance() { }

    public Balance(Guid resourceId, decimal quantity)
    {
        ResourceId = resourceId;
        Quantity = quantity;
    }

    public void Increase(decimal amount)
    {
         // Инварианты
        if (amount <= 0)
            throw new ArgumentException("Количество должно быть положительным");

        Quantity += amount;
    }

    public void Decrease(decimal amount)
    {
        // Инварианты
        if (amount <= 0)
            throw new ArgumentException("Количество должно быть положительным");

        if (Quantity < amount)
            throw new InvalidOperationException("Недостаточно остатка");

        Quantity -= amount;
    }
}