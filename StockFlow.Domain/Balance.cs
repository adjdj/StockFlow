/*!
 * @file Balance.cs
 * @brief Агрегат "Баланс" - на складе есть остаток ресурса в конкретной единице измерения
 * @author -
 * @copyright -
 * @details
 *
 */
namespace StockFlow.Domain;

public class Balance {
    public Guid Id { get; private set; }

    public Guid ResourceId { get; private set; }
    //public Unit UnitId { get; private set; } = null!;

    public decimal Quantity { get; private set; }

    private Balance() { }


    public Balance(Guid resourceId/*, Unit unit*/) {
        Id = Guid.NewGuid();
        ResourceId = resourceId;
        //Unit = unit;
        Quantity = 0;
    }

    // Навигационное свойство
    // EF поймет связь автоматически
    public Resource? Resource { get; set; } = null;

    public void Increase(decimal amount) {
        if (amount <= 0)
            throw new DomainException("Amount must be positive");

        Quantity += amount;
    }


    public void Decrease(decimal amount) {
        if (amount <= 0)
            throw new DomainException("Amount must be positive");

        if (Quantity < amount)
            throw new DomainException("Insufficient balance");

        Quantity -= amount;
    }
}