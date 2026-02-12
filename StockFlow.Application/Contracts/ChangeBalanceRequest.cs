namespace StockFlow.Application.Contracts;

public record ChangeBalanceRequest(Guid ResourceId, Guid UnitId, decimal Amount);

