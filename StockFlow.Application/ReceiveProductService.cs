namespace StockFlow.Application;

public class ReceiveProductService {
    private readonly IProductRepository _repository;


    public ReceiveProductService(IProductRepository repository) {
        _repository = repository;
    }


    public async Task ReceiveAsync(Guid productId, decimal amount) {
        var product = await _repository.GetAsync(productId) ?? throw new InvalidOperationException("Product not found");

        product.Receive(amount);

        await _repository.SaveAsync();

        product.Issue(Math.Abs(amount));



    }
}