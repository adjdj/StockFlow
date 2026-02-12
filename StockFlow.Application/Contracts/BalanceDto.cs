namespace StockFlow.Application.Contracts;

public record BalanceDto(Guid Id, string ResourceName, string UnitName, decimal Quantity);