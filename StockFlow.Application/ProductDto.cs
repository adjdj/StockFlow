namespace StockFlow.Application;

public record ProductDto(
    Guid Id,
    string Name,
    string ResourceName,
    //string Unit,
    decimal Balance
    );