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
    public Guid UnitId { get; private set; }

    public decimal Quantity { get; private set; }

    private Balance() { }


    public Balance(Guid resourceId, Guid unitId) {
        Id = Guid.NewGuid();
        ResourceId = resourceId;
        UnitId = unitId;
        Quantity = 0;
    }

    public Resource? Resource { get; set; } = null; // EF

    public void Increase(decimal amount) {

        Console.WriteLine("Ошшшибка: amount = {0}", amount);
        if (amount <= 0)
            throw new DomainException("Неверное количество");

        Quantity += amount;
    }


    public void Decrease(decimal amount) {
        if (amount <= 0)
            throw new DomainException("Неверное количество");

        if (Quantity < amount)
            throw new DomainException("Недостаточный баланс");

        Quantity -= amount;
    }
}