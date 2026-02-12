namespace StockFlow.Application.Contracts;

public record ChangeBalanceRequest(Guid ResourceId, Guid Unit, decimal Amount);