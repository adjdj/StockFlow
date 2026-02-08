namespace StockFlow.Application.Contracts;

public record ChangeBalanceRequest(Guid ResourceId,/*string Unit, decimal Ratio,*/decimal Amount);