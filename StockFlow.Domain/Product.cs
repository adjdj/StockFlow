using StockFlow.Domain;

namespace StockFlow.Domain;

public class Product : Entity {
    public Guid ResourceId { get; private set; }

    public string Name { get; private set; } = null!;
    //public UnitOfMeasure Unit { get; private set; } = null!;
    public Balance Balance { get; private set; } = null!;


    private Product() { }


    public Product(Guid resourceId, string name/*, UnitOfMeasure unit*/) {
        ResourceId = resourceId;
        Name = name;
        //Unit = unit;
        Balance = new Balance();
    }


    public void Receive(decimal amount)
    => Balance.Increase(amount);


    public void Issue(decimal amount)
    => Balance.Decrease(amount);
}