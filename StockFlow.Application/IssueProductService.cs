namespace StockFlow.Application;

public class IssueProductService {
    private readonly IProductRepository _repository;


    public IssueProductService(IProductRepository repository) {
        _repository = repository;
    }


    public async Task IssueAsync(Guid productId, decimal amount) {
        var product = await _repository.GetAsync(productId) ?? throw new InvalidOperationException("Product not found");
        product.Issue(Math.Abs(amount));
        await _repository.SaveAsync();
    }
}