namespace StockFlow.Application.Contracts;

public record BalanceDto(Guid Id, Guid ResourceId, string ResourceName, /*string Unit,*/decimal Quantity);