namespace StockFlow.Domain;

public class Balance : Entity {
    public decimal Quantity { get; private set; }

    /// <summary>Для репозитория</summary>
    private Balance() { }


    public Balance(decimal initial = 0) {
        Quantity = initial;
    }

    public void Increase(decimal amount) {
        if (amount <= 0)
            throw new DomainException("Amount must be positive");
        Quantity += amount;
    }

    public void Decrease(decimal amount) {
        if (amount <= 0)
            throw new DomainException("Amount must be positive");
        if (Quantity < amount)
            throw new DomainException("Insufficient stock");
        Quantity -= amount;
    }
}